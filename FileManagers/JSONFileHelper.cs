using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieAssignmentInterfaces.MediaObjects;
using Newtonsoft.Json;
using System;

namespace MovieAssignmentInterfaces.FileManagers
{
    public class JSONFileHelper: IMediaHelper
    {
        private const string MoviePath = "Files//movies.json";
        private const string ShowPath = "Files//shows.json";
        private const string VideoPath = "Files//videos.json";
        public List<Shows> ShowsList = new List<Shows>();
        public List<Movie> MovieList = new List<Movie>();
        public List<Video> VideoList = new List<Video>();

        public void Shows()
        {
            List<Shows> shows = JsonConvert.DeserializeObject<List<Shows>>(ShowPath);
            ShowsList = shows;
        }

        public void Movies()
        {
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(MoviePath);
            MovieList = movies;
        }

        public void Videos()
        {
            List<Video> videos = JsonConvert.DeserializeObject<List<Video>>(VideoPath);
            VideoList = videos;
        }
        
        public void MovieAdd(Movie movie)
        {
            
        }
        public void ShowAdd(int id, string title, int season, int episode, List<string> writers)
        {
            
        }

        public void MovieAdd(int id, string title, List<string> genres)
        {
            
            
        }

        public void VideoAdd(int id, string title, List<string> format, int length, List<int> regions)
        {
            
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
    }
}