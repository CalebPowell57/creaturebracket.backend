// See https://aka.ms/new-console-template for more information

using DataGenerator;
using Newtonsoft.Json;
using System.Data.SqlClient;

var configurationJson = File.ReadAllText("configuration.json");

var configuration = JsonConvert.DeserializeObject<Configuration>(configurationJson);

var connection = new SqlConnection(configuration.ConnectionString);

await connection.OpenAsync();

using (var transaction = connection.BeginTransaction())
{
    try
    {
        var command = connection.CreateCommand();

        var scriptNames = Directory.GetFiles("Scripts");

        var scripts = scriptNames.Select(n => File.ReadAllText(n));

        foreach (var script in scripts)
        {
            command.CommandText += $"{script}\n\n";
        }

        command.Transaction = transaction;

        var rowsAffected = await command.ExecuteNonQueryAsync();

        Console.WriteLine($"Data has been successfully generated! ({rowsAffected} rows have been added)");

        await transaction.CommitAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.ReadLine();
}