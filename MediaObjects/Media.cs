using CsvHelper.Configuration.Attributes;

namespace AbstractMovieAssignment.MediaObjects
{
    public abstract class Media
    {
        [Name("Id","showId","movieId","videoId")]public int Id { get; set; }
        [Name("title")]public string title { get; set; }

        public abstract string Display();
        

    }
}