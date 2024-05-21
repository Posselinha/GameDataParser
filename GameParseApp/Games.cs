namespace GameDataParser.GameParseApp
{
    public class Games
    {
        public string Title { get; }
        public int ReleaseYear { get; }
        public double Rating { get; }

        public Games(string title, int releaseYear, double rating)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Rating = rating;
        }

        public override string ToString() =>
            $"{Title}, lançado em {ReleaseYear}, rating: {Rating}";
    }
}
