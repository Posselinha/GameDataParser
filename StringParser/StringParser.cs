using GameDataParser.GameParseApp;
using GameDataParser.Logger;
using System.Text.Json;

namespace GameDataParser.StringParser
{

    public class StringParser : IStringParser
    {
        private readonly ILogger _logger;
        public StringParser(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<Games> Read(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 0)
            {
                var fileContent = File.ReadAllText(filePath);
                try
                {
                    return JsonSerializer.Deserialize<IEnumerable<Games>>(fileContent);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON do arquivo {filePath} não está em um formato válido!\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JSON Body:\n" + fileContent + Environment.NewLine);
                    Console.ResetColor();

                    _logger.LogErrorMessage(ex);
                    throw new JsonException();
                }
            }
            else
            {
                return new List<Games>();
            }
        }
    }
}
