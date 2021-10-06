using System;
using System.Net.Http.Headers;
using NLog;
using System.Collections.Generic;
using System.Linq;
using AbstractMovieAssignment.FileManagers;

namespace AbstractMovieAssignment
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static CsvFileHelper CsvFileHelper = new CsvFileHelper();
        private static Menu Menu = new Menu();
        static void Main(string[] args)
        {
            int option = 0;
            int choice = 0;

            while (option != 4)
            {
                Menu.Display();
                option = Menu.ValueGetter();
                switch (option)
                {
                    //movies
                    case 1:
                        Console.WriteLine("Do you want to\n1.)Display\n2.)Add");
                        logger.Trace("User chose option 1: Movies");
                        choice = Menu.ValueGetter();
                        CsvFileHelper.Movies();
                        switch (choice)
                        {
                            case 1:
                            {
                                logger.Trace("User chose to search movies");
                                Console.WriteLine("What would you like to search?(Enter for all)");
                                string search = Console.ReadLine();
                                CsvFileHelper.SearchMedia("Movie", search);
                                break;
                            }
                            case 2:
                            {
                                logger.Trace("User chose to add movie");
                                List<string> genresPicked = new List<string>();
                                int id = CsvFileHelper.MovieList.Last().Id+1;
                                System.Console.WriteLine("What is the title of the film?");
                                string title = Console.ReadLine();
                                Console.WriteLine("What year was the movie made in?");
                                title = title + " (" + Console.ReadLine() + ")";
                                while (DuplicateChecker(title, "Movie")) 
                                {
                                    System.Console.WriteLine($"The film you picked already exists in enter a new one");
                                    title = Console.ReadLine();
                                    Console.WriteLine("Enter the year of the film");
                                    title = title + " (" + Console.ReadLine() + ")";
                                }
                                System.Console.WriteLine("How many genres do you want to add?");
                                int genreAmount = Menu.ValueGetter();
                                for (int i = 0; i < genreAmount; i++)
                                {
                                    System.Console.WriteLine($"What is the {i + 1} genre?");
                                    genresPicked.Add(Console.ReadLine());
                                
                                }
                                CsvFileHelper.MovieAdd(id, title, string.Join("|", genresPicked));
                                break;
                            }
                            default:
                                logger.Trace("User made invalid input");
                                Console.WriteLine("Sorry not a choice!");
                                break;
                        }
                        break;
                    //Shows
                    case 2:
                        logger.Trace("User chose option 2: Shows");
                        Console.WriteLine("Do you want to\n1.)Display \n2.)Add");
                        choice = Menu.ValueGetter();
                        CsvFileHelper.Shows();//reads the videos file and makes the list for it in the CSVFile Class
                        switch (choice)
                        {
                            case 1:
                            {
                                logger.Trace("User chose to search shows");
                                Console.WriteLine("What would you like to search?(Enter for all)");
                                string search = Console.ReadLine();
                                CsvFileHelper.SearchMedia("Show", search);
                                break;
                            }
                            case 2:
                            {
                                logger.Trace("User chose to add show");
                                List<string> writers = new List<string>();
                                int id = CsvFileHelper.ShowsList.Last().Id + 1;
                                Console.WriteLine("What is the title of the show?");
                                string title = Console.ReadLine();
                                while (DuplicateChecker(title, "Show"))
                                {
                                    Console.WriteLine("That show already exists try another");
                                    title = Console.ReadLine();
                                }
                                Console.WriteLine("How many seasons are in the show?");
                                int seasons = Menu.ValueGetter();
                                Console.WriteLine("How many episodes?");
                                int episodes = Menu.ValueGetter();
                                Console.WriteLine("How many writers are there?");
                                int writerCount = Menu.ValueGetter();
                                for (int i = 0; i < writerCount; i++)
                                {
                                    Console.WriteLine($"What is the name of writer #{i + 1}");
                                    writers.Add(Console.ReadLine());
                                }
                                CsvFileHelper.ShowAdd(id, title, seasons, episodes, string.Join('|', writers));
                                break;
                            }
                            default:
                                logger.Trace("User made invalid input");
                                Console.WriteLine("Sorry not a choice!");
                                break;
                        }
                        break;
                    //Videos
                    case 3:
                        logger.Trace("User chose option 3:Videos");
                        Console.WriteLine("Do you want to \n1.)Display\n2.)Add");
                        choice = Menu.ValueGetter();
                        CsvFileHelper.Videos();//reads the videos file and makes the list for it in the CSVFile Class
                        switch (choice)
                        {
                            case 1:
                            {
                                logger.Trace("User chose to search videos ");
                                Console.WriteLine("What would you like to search?(Enter for all)");
                                string search = Console.ReadLine();
                                CsvFileHelper.SearchMedia("Video", search);
                                break;
                            }
                            case 2:
                            {
                                logger.Trace("User chose to add a video");
                                List<string> regions = new List<string>();
                                List<string> formats = new List<string>();
                                int id = CsvFileHelper.VideoList.Last().Id + 1;
                                Console.WriteLine("What is the title of the video?");
                                string title = Console.ReadLine();
                                while (DuplicateChecker(title,"Video"))
                                {
                                    Console.WriteLine("This Video already exists enter a new title");
                                    title = Console.ReadLine();
                                }
                                Console.WriteLine("How many formats is the video on?");
                                int formatTotals = Menu.ValueGetter();
                                for (int i = 0; i < formatTotals; i++)
                                {
                                    Console.WriteLine($"Format #{i + 1}");
                                    formats.Add(Console.ReadLine());
                                }
                                Console.WriteLine("What is the format of the video? Ex.DVD,Bluray,VHS");
                                string format = Console.ReadLine();
                                Console.WriteLine("How many minutes long is the video?");
                                int length = Menu.ValueGetter();
                                Console.WriteLine("How many regions is it in?");
                                int regionsCount = Menu.ValueGetter();
                                for (int i = 0; i < regionsCount; i++)//I don't know the region codes so I made them on the spot
                                {
                                    Console.WriteLine($"Region #{i + 1}?");
                                    Console.WriteLine("0.)North America\n1.)South America\n2.)Europe\n3.)Asia\n4.)Australia\n5.)Antarctica");
                                    regions.Add(Console.ReadLine());
                                }
                                CsvFileHelper.VideoAdd(id, title, string.Join('|', format), length, string.Join('|', regions));
                                break;
                            }
                            default:
                                logger.Trace("User made an invalid input");
                                Console.WriteLine("Sorry not a choice!");
                                break;
                        }
                        break;
                    //Exit
                    case 4:
                        logger.Debug("User exited the program");
                        Console.WriteLine("Goodbye!");
                        break;
                    //wrong input
                    default:
                        logger.Debug($"User chose {option} not valid");
                        Console.WriteLine("That isn't an option sorry!");
                        break;

                }

            }
        }
        public static bool DuplicateChecker(string chosenMedia, string type)
        {
            bool contained = false;
            switch (type)
            {
                case "Movie":
                    CsvFileHelper.Movies();
                    foreach (var media in CsvFileHelper.MovieList)
                    {
                        if (media.title.ToLower().Equals(chosenMedia.ToLower()))
                        {
                            contained = true;
                            break;
                        }
                    }
                    break;
                case "Show":
                    CsvFileHelper.Movies();
                    foreach (var media in CsvFileHelper.MovieList)
                    {
                        if (media.title == chosenMedia)
                        {
                            contained = true;
                            break;
                        }

                    }
                    break;
                case "Video":
                    CsvFileHelper.Videos();
                    foreach (var media in CsvFileHelper.VideoList)
                    {
                        if (media.title == chosenMedia)
                        {
                            contained = true;
                            break;
                        }
                    }
                    break;
            }

            return contained;
        }
        
    }
}