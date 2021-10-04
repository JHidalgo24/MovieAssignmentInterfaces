using AbstractMovieAssignment.MediaObjects;
using CsvHelper.Configuration;

namespace AbstractMovieAssignment.ClassMaps
{
    public class MovieClassMap : ClassMap<Movie>
    {

        public MovieClassMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.title).Index(1).Name("title");
            Map(m => m.genres).Index(2).Name("genres");
        }
    }
}