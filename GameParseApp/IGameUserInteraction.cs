namespace GameDataParser.GameParseApp
{
    public interface IGameUserInteraction
    {
        void ShowFromFile();
        void ShowAvailableGames(string filePath);
        void GameExit();
    }
}
