using DND5E.Service.Services;

namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFRaceAttribute : System.Attribute
    {
        public PDFRaceAttribute()
        {
            
        }

        public async Task<string> GetRace(Dictionary<string, string> fields, SubraceService subraceService)
        {
            var subrace = fields.GetValueOrDefault("race");

            var race = await subraceService.GetRaceFromSubraceName(subrace);

            return race;
        }
    }
}
