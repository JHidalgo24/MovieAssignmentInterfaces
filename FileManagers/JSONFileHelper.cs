using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieAssignmentInterfaces.MediaObjects;
using Newtonsoft.Json;
using System;

namespace MovieAssignmentInterfaces.FileManagers
{
    public class JSONFileHelper : IMediaHelper
    {
        private const string MoviePath = "Files//movies.json";
        private const string ShowPath = "Files//shows.json";
        private const string VideoPath = "Files//videos.json";
        public List<Shows> ShowsList = new List<Shows>();
        public List<Movie> MovieList = new List<Movie>();
        public List<Video> VideoList = new List<Video>();

        public JSONFileHelper()//reads the files into their list as soon as JSONFileHelper is made 
        {
            Shows();
            Movies();
            Videos();
        }
        public void WriteLists()
        {
            string jsonMovie = JsonConvert.SerializeObject(MovieList, Formatting.Indented);
            File.WriteAllText(MoviePath, jsonMovie);

            string jsonVideo = JsonConvert.SerializeObject(VideoList, Formatting.Indented);
            File.WriteAllText(VideoPath, jsonVideo);

            string jsonShow = JsonConvert.SerializeObject(ShowsList, Formatting.Indented);
            File.WriteAllText(ShowPath, jsonShow);
        }

        public void Shows()
        {
            try
            {
                string json = File.ReadAllText(ShowPath);
                ShowsList = JsonConvert.DeserializeObject<List<Shows>>(json);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read JSON file to List");
            }
        }

        public void Movies()
        {
            try
            {
                string json = File.ReadAllText(MoviePath);
                MovieList = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read JSON file to List");
            }
        }

        public void Videos()
        {
            try
            {
                string json = File.ReadAllText(VideoPath);
                VideoList = JsonConvert.DeserializeObject<List<Video>>(json);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read JSON file to List");
            }
        }


        public void ShowAdd(int id, string title, int season, int episode, List<string> writers)
        {
            Shows temp = new Shows();
            temp.Id = id;
            temp.title = title;
            temp.season = season;
            temp.episode = episode;
            temp.writers = writers;
            ShowsList.Add(temp);
            string json = JsonConvert.SerializeObject(ShowsList, Formatting.Indented);
            File.WriteAllText(ShowPath, json);
        }

        public void MovieAdd(int id, string title, List<string> genres)
        {
            Movie temp = new Movie();
            temp.Id = id;
            temp.title = title;
            temp.Genres = genres;
            MovieList.Add(temp);
            string json = JsonConvert.SerializeObject(MovieList, Formatting.Indented);
            File.WriteAllText(MoviePath, json);
        }

        public void VideoAdd(int id, string title, List<string> format, int length, List<int> regions)
        {
            Video temp = new Video();
            temp.Id = id;
            temp.title = title;
            temp.Format = format;
            temp.Length = length;
            temp.Regions = regions;
            VideoList.Add(temp);
            string json = JsonConvert.SerializeObject(VideoList, Formatting.Indented);
            File.WriteAllText(VideoPath, json);
        }
        

        public void SearchMedia(string title)
        {
            List<Media> foundMedia = new List<Media>();
            
            MovieList.Where(c => c.title.ToLower().Contains(title.ToLower())).ToList().ForEach(c => foundMedia.Add(c));
            ShowsList.Where(c => c.title.ToLower().Contains(title.ToLower())).ToList().ForEach(c => foundMedia.Add(c));
            VideoList.Where(c => c.title.ToLower().Contains(title.ToLower())).ToList().ForEach(c => foundMedia.Add(c));

            System.Console.WriteLine($"There are {foundMedia.Count} matched searches! for '{title}'");
            foreach (var x in foundMedia)
            {
                Console.WriteLine(x.Display());
            }

        }
    }
}