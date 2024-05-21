namespace GameDataParser.GameParseApp
{
    public class GameParserApp
    {
        private readonly IGameUserInteraction _gameUserInteration;
        public GameParserApp(IGameUserInteraction gameUserInteration)
        {
            _gameUserInteration = gameUserInteration;
        }
        public void Run()
        {
            _gameUserInteration.ShowFromFile();
            _gameUserInteration.GameExit();
        }
    }
}
