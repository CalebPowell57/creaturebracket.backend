using CharacterImport.Attribute;
using CharacterImport.Dto;
using CharacterImport.Dto.ImportField;
using CharacterImport.Helpers;
using DND5E.Service.Services;
using System.ComponentModel;
using System.Reflection;

namespace CharacterImport.Services
{
    public class DnDBeyondService 
    {
        private SubraceService _subraceService;

        public DnDBeyondService(SubraceService subraceService)// : base("https://character-service.dndbeyond.com/character/v5/character/")
        {
            _subraceService = subraceService;
        }

        //public async Task<CharacterDto> Import(long characterId)
        //{
        //    var response = await Get<ResponseDto>($"{characterId}");

        //    if(response.Success)
        //    {
        //        return response.Character;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<CharacterDto> ParsePDF(string base64PDF)
        {
            var bytes = Convert.FromBase64String(base64PDF);

            var text = System.Text.Encoding.UTF8.GetString(bytes);

            var lines = text
                .Replace("\\n", "{endlineplaceholder}")
                .Split(
                    new string[] { "\n" },
                    StringSplitOptions.None
                )
                .Select(x => x
                    .Replace("{endlineplaceholder}", "\n")
                    .Replace("\\200", "")
                    .Replace("\\204", "-")
                    .Replace("\\220", "'")
                    .Replace("\\215", "\"")
                    .Replace("\\216", "\"")
                    .Replace("\\(", "(")
                    .Replace("\\)", ")")
                );

            var fieldValues = "";
            var currentKey = "";
            var currentValue = "";

            var fieldDictionary = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                if (line.StartsWith("/TU(") && line.EndsWith(")"))
                {
                    currentValue = "";
                    currentKey = line.Replace("/TU(", "").TrimEnd(')').ToLower().Trim();
                }
                else if (line.StartsWith("/T(") && line.EndsWith(")"))
                {
                    currentValue = "";
                    currentKey = line.Replace("/T(", "").TrimEnd(')').ToLower().Trim();
                }
                else if (line.StartsWith("/V(") && line.EndsWith(")") && !fieldDictionary.ContainsKey(currentKey))
                {
                    fieldDictionary.Add(currentKey, line.Replace("/V(", "").TrimEnd(')').Trim());
                }
                else if (line.StartsWith("(") && line.TrimEnd().EndsWith(") Tj") && !fieldDictionary.ContainsKey(currentKey))
                {
                    currentValue += line.Substring(1, line.Length - 1).Replace(") Tj", "");
                }
                else if (line.ToLower() == "et q emc" && !string.IsNullOrWhiteSpace(currentValue))
                {
                    fieldDictionary.Add(currentKey, currentValue.Trim());
                }
            }

            var unmappedProps = new List<string>();

            var fields = new List<FieldDto>();

            var character = new CharacterDto();

            foreach (var property in character.GetType().GetProperties())
            {
                var ignore = property.GetCustomAttribute<PDFIgnoreAttribute>() is not null;

                if (ignore)
                {
                    continue;
                }

                var fieldName = property.GetCustomAttribute<PDFFieldAttribute>()?.FieldName.ToLower() ?? property.Name.ToLower();
                var split = property.GetCustomAttribute<PDFSplitAttribute>();
                var defaultValue = property.GetCustomAttribute<PDFDefaultValueAttribute>();
                var race = property.GetCustomAttribute<PDFRaceAttribute>();
                var section = property.GetCustomAttribute<PDFSectionAttribute>();
                var speed = property.GetCustomAttribute<PDFSpeedAttribute>();
                var table = property.GetCustomAttribute<PDFTableAttribute>();
                var whitespaceToBoolAttribute = property.GetCustomAttribute<PDFWhitespaceToBoolAttribute>();

                object value = null;

                var fieldTitle = property.Name;
                var fieldStatus = Constants.FieldStatus.Success;

                try
                {
                    if (race is not null)
                    {
                        value = await race.GetRace(fieldDictionary, _subraceService);
                    }
                    else if (table is not null)
                    {
                        var childType = property.PropertyType.GetGenericArguments()[0];

                        var childPropertyFieldDictionary = childType
                            .GetProperties()
                            .Select(p => (
                                p,
                                p.GetCustomAttribute<PDFFieldAttribute>()?.FieldName.ToLower() ?? p.Name.ToLower()
                            ));

                        var tableFieldDictionary = fieldDictionary
                            .Where(f => !f.Key.Contains("header") && childPropertyFieldDictionary
                                .Select(c => $"{table.Name}{c.Item2}"
                                    .ToLower()
                                    .Trim()
                                )
                                .Any(n => f.Key.StartsWith(n))
                            );

                        var tableRows = new List<PDFTableRow>();

                        foreach (var tableField in tableFieldDictionary)
                        {
                            foreach (var columnName in childPropertyFieldDictionary.Select(x => x.Item2))
                            {
                                var partialName = $"{table.Name}{columnName}";

                                if (tableField.Key.StartsWith(partialName))
                                {
                                    var rowNumber = int.Parse(tableField.Key.Substring(partialName.Length));

                                    var tableRow = tableRows.SingleOrDefault(x => x.RowNumber == rowNumber);

                                    if (tableRow is null)
                                    {
                                        tableRow = new PDFTableRow
                                        {
                                            RowNumber = rowNumber,
                                            Columns = new Dictionary<string, string>()
                                        };

                                        tableRows.Add(tableRow);
                                    }

                                    tableRow.Columns.Add(columnName, tableField.Value);
                                }
                            }
                        }

                        var tableValue = Array.CreateInstance(childType, tableRows.Count);

                        for (var tableRowIndex = 0; tableRowIndex < tableRows.Count; tableRowIndex++)
                        {
                            var childObject = Activator.CreateInstance(childType);

                            var tableRow = tableRows[tableRowIndex];

                            foreach (var childPropertyField in childPropertyFieldDictionary)
                            {    
                                if (tableRow.Columns.TryGetValue(childPropertyField.Item2, out var columnValue))
                                {
                                    childPropertyField.Item1.SetValue(childObject, columnValue);
                                }
                                else
                                {
                                    unmappedProps.Add($"{property.Name}[{tableRow.RowNumber}].{childPropertyField.Item1.Name}");
                                }
                            }

                            tableValue.SetValue(childObject, tableRowIndex);
                        }

                        Type genericListType = typeof(List<>);
                        Type concreteListType = genericListType.MakeGenericType(childType);

                        value = Activator.CreateInstance(concreteListType, new object[] { tableValue });
                    }
                    else if (section is not null && fieldDictionary.TryGetValue(section.FieldName.ToLower(), out var sectionValue))
                    {
                        var splitSection = sectionValue.Split("===");

                        var index = splitSection
                            .Select(x => x.Trim().ToLower())
                            .ToList()
                            .IndexOf(section.SectionName.ToLower().Trim());

                        if (index != -1)
                        {
                            value = splitSection[index + 1];
                        }
                    }
                    else if (split is not null)
                    {
                        var field = fieldDictionary.SingleOrDefault(f => f.Key.Split(split.NameSeparator).Any(x => x.Trim() == fieldName));

                        var s = field.Key.Split(split.NameSeparator).Select(x => x.Trim()).ToList();
                        var index = s.IndexOf(fieldName);
                        var preConvertedValue = field.Value.Split(split.ValueSeparator).Select(x => x.Trim()).ToList()[index];

                        var propertyType = property.PropertyType;
                        var converter = TypeDescriptor.GetConverter(propertyType);
                        value = converter.ConvertFromString(preConvertedValue);
                    }
                    else if (fieldDictionary.TryGetValue(fieldName.ToLower(), out var fieldValue))
                    {
                        if (speed is not null)
                        {
                            fieldValue = fieldValue.Substring(0, 2).Trim();
                        }

                        if (whitespaceToBoolAttribute is not null)
                        {
                            fieldValue = (!string.IsNullOrWhiteSpace(fieldValue)).ToString();
                        }

                        var propertyType = property.PropertyType;
                        var converter = TypeDescriptor.GetConverter(propertyType);

                        try
                        {
                            value = converter.ConvertFromString(fieldValue);
                        }
                        catch (Exception ex)
                        {
                            if (defaultValue is not null)
                            {
                                value = defaultValue.DefaultValue;
                            }
                            else
                            {
                                unmappedProps.Add(property.Name);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        //unmappedProps.Add(property.Name);
                        fieldStatus = Constants.FieldStatus.Empty;
                        
                        fields.Add(new FieldDto
                        {
                            PropertyName = property.Name,
                            Title = fieldTitle,
                            Value = value,
                            Status = fieldStatus,
                        });

                        continue;
                    }

                    property.SetValue(character, value);
                }
                catch (Exception ex)
                {
                    fieldStatus = Constants.FieldStatus.Failed;

                    var b = ex;
                }

                fields.Add(new FieldDto
                {
                    PropertyName = property.Name,
                    Title = fieldTitle,
                    Value = value,
                    Status = fieldStatus,
                });
            }

            //var unmapped = string.Join('\n', unmappedProps);

            return character;
        }
    }
}
