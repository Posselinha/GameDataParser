using GameDataParser.GameParseApp;
using GameDataParser.Logger;
using GameDataParser.StringParser;

var GameParserApp = new GameParserApp(
    new GameUserInteraction(
        new StringParser(new Logger())));

GameParserApp.Run();