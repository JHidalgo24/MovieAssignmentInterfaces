using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using MovieAssignmentInterfaces.ClassMaps;
using MovieAssignmentInterfaces.MediaObjects;

namespace MovieAssignmentInterfaces.FileManagers
{
    public class CsvFileHelper : IMediaHelper
   {
        
        private const string MoviePath = "Files//movies.csv";
        private const string ShowPath = "Files//shows.csv";
        private const string VideoPath = "Files//videos.csv";
        public List<Shows> ShowsList { get; set; }
        public List<Movie> MovieList { get; set; }
        public List<Video> VideoList { get; set; }
        public CsvFileHelper()//reads the files into their list as soon as CsvFileHelper is made 
        {
            Shows();
            Movies();
            Videos();
        }

        public void Shows()
        {
            try
            {

                using (var streamReader =
                    new StreamReader(ShowPath))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Shows>().ToList();
                    ShowsList = records;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't read file");
                throw;
            }
        }
        public void Videos()
        {

            try
            {

                using (var streamReader =
                    new StreamReader(VideoPath))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Video>().ToList();
                    VideoList = records;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't read file");
                throw;
            }
        }
        public void Movies()
        {

            try
            {

                using (var streamReader =
                    new StreamReader(MoviePath))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Movie>().ToList();
                    MovieList = records;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't read file");
                throw;
            }
        }
        public void ShowAdd(int id, string title, int season, int episode, List<string> writers)
        {

            var records = new List<Shows> { new Shows {episode = episode, Id = id, season = season, title = title, writers = writers} };
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
            using (var stream = File.Open(ShowPath,
                FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<ShowClassMap>();
                csv.WriteRecords(records);
            }

        }
        public void VideoAdd(int id, string title, List<string> format, int length, List<int> regions)
        {

            var records = new List<Video> { new Video { Id = id, title = title, Format = format, Length = length, Regions = regions } };
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
            using (var stream = File.Open(VideoPath,
                FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<VideosClassMap>();
                csv.WriteRecords(records);
            }
        }
        public void MovieAdd(int id, string title, List<string> genres)
        {

            var records = new List<Movie> { new Movie { Id = id, title = title, Genres = genres } };
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
            using (var stream = File.Open(MoviePath,
                FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<MovieClassMap>();//tells the CSVwriter the order to use
                csv.WriteRecords(records);
            }
        }
        public void SearchMedia(string type, string title)
        {
            switch (type)
            {
                case "Show":
                    if (title != "")
                    {
                        foreach (var show in ShowsList)
                        {
                            if (show.title.ToLower().Contains(title.ToLower()))
                            {
                                Console.WriteLine(show.Display());
                            }

                        }
                    }
                    else if (title == "")
                    {
                        foreach (var show in ShowsList)
                        {
                            Console.WriteLine(show.Display());
                        }
                    }
                    break;
                case "Movie":
                    {
                        Movies();
                        if (title != "")
                        {
                            foreach (var movie in MovieList)
                            {
                                if (movie.title.ToLower().Contains(title.ToLower()))
                                {
                                    Console.WriteLine(movie.Display());
                                }

                            }
                        }
                        else if (title == "")
                        {
                            foreach (var movie in MovieList)
                            {
                                Console.WriteLine(movie.Display());
                            }
                        }
                    }
                    break;
                case "Video":
                    {
                        if (title != "")
                        {
                            foreach (var video in VideoList)
                            {
                                if (video.title.ToLower().Contains(title.ToLower()))
                                {
                                    Console.WriteLine(video.Display());
                                }

                            }
                        }
                        else if (title == "")
                        {
                            foreach (var video in VideoList)
                            {
                                Console.WriteLine(video.Display());
                            }
                        }
                    }
                    break;
            }
        }

        public void WriteLists()
        {
            var movies = MovieList;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
            using (var stream = File.Open(MoviePath,
                FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<MovieClassMap>();//tells the CSVwriter the order to use
                csv.WriteRecords(movies);
            }

            //video
            var videos = VideoList;
            config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
            using (var stream = File.Open(VideoPath,
                FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<VideosClassMap>();//tells the CSVwriter the order to use
                csv.WriteRecords(videos);
            }
            
            //shows
            var shows = ShowsList;
            config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
            using (var stream = File.Open(ShowPath,
                FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<ShowClassMap>();//tells the CSVwriter the order to use
                csv.WriteRecords(shows);
            }
        }
    }
}