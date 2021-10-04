using AbstractMovieAssignment.MediaObjects;
using CsvHelper.Configuration;

namespace AbstractMovieAssignment.ClassMaps
{
    public class VideosClassMap:ClassMap<Video>
    {
        public VideosClassMap()
        {
            Map(m => m.Id).Index(0).Name("videoId");
            Map(m => m.title).Index(1).Name("title");
            Map(m => m.Format).Index(2).Name("format");
            Map(m => m.Length).Index(3).Name("length");
            Map(m => m.RegionsString).Index(4).Name("regions");
        }
    }
}