using CsvHelper.Configuration.Attributes;

namespace AbstractMovieAssignment.MediaObjects
{
    public class Movie : Media
    {
        [Name("genres")] public string genres { get; set; }
        private string[] genresArray { get; set; }


        public string[] GenresArray()
        {
            genresArray = genres.Split('|');
            return genresArray;
        }

        public override string Display()
        {
            return $"MovieId:{Id} Title:{title} Genres:{genres}";
        }
    }
}