using GameDataParser.StringParser;
using System.Text.Json;

namespace GameDataParser.GameParseApp
{
    public class GameUserInteraction : IGameUserInteraction
    {
        private readonly IStringParser _stringParser;
        private bool ShallStop = false;

        public GameUserInteraction(IStringParser stringParser)
        {
            _stringParser = stringParser;
        }

        public void ShowFromFile()
        {
            while (!ShallStop)
            {
                Console.WriteLine("Insira o nome do arquivo que você deseja ler\n\n" +
                    "Arquivos disponiveis:\n" +
                    "'games.json'\n" +
                    "'gamesInvalidFormat.json'\n");
                try
                {
                    var userInput = Console.ReadLine();
                    ShowAvailableGames(userInput);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("O valor não pode ser nulo! Verifique se você não apertou " +
                        "'CTRL + Z' sem querer.\n");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("O valor não pode ser vazio! Insira um valor válido.\n");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Arquivo não encontrado! Insira o nome de um arquivo válido.\n");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Desculpe, ocorreu um problema interno com o aplicativo e ele precisará ser fechado!\n");
                    ShallStop = true;
                }
            }
        }

        public void ShowAvailableGames(string filePath)
        {
            var allGames = _stringParser.Read(filePath);

            if (allGames.Count() > 0)
            {
                foreach (var game in allGames)
                {
                    Console.WriteLine(game);
                }
            }
            else
            {
                Console.WriteLine("Não há nenhum jogo presente no arquivo selecionado!");
            }
            ShallStop = true;
        }

        public void GameExit()
        {
            Console.WriteLine("Aperte qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
