using GameDataParser.GameParseApp;

namespace GameDataParser.StringParser
{
    public interface IStringParser
    {
        IEnumerable<Games> Read(string filePath);
    }
}
