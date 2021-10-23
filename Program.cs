using System;
using System.Collections.Generic;
using System.Linq;
using MovieAssignmentInterfaces.FileManagers;
using NLog;

namespace MovieAssignmentInterfaces
{
    internal class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static JSONFileHelper FileHelper = new();//you can change JSONFileHelper to CSVFileHelper and should still work  
        private static Menu Menu = new();//helps with menu options and getting ints

        private static void Main(string[] args)
        {
            var option = 0;//picks the media
            while (option != 5)
            {
                Menu.Display();
                option = Menu.ValueGetter();
                var choice = 0;//picks for the options inside the media 
                switch (option)
                {
                    //movies
                    case 1:
                        Console.WriteLine("Do you want to\n1.)Display\n2.)Add");
                        logger.Trace("User chose option 1: Movies");
                        choice = Menu.ValueGetter();
                        FileHelper.Movies();
                        switch (choice)
                        {
                            case 1:
                            {
                                Console.WriteLine($"Range number 1 (1-{FileHelper.MovieList.Count})");
                                var range1 = Menu.ValueGetter();
                                while (range1 > FileHelper.MovieList.Count || range1 <= 0)
                                {
                                    Console.WriteLine(
                                        $"Invalid Number!\nEnter new number (1-{FileHelper.MovieList.Count})");
                                    range1 = Menu.ValueGetter();
                                }

                                Console.WriteLine($"Range number 2 ({range1}-{FileHelper.MovieList.Count})");
                                var range2 = Menu.ValueGetter();
                                while (range2 < range1 || range2 > FileHelper.MovieList.Count)
                                {
                                    Console.WriteLine(
                                        $"Invalid Number\nEnter new number from ({range1}-{FileHelper.MovieList.Count})");
                                    range2 = Menu.ValueGetter();
                                }

                                for (var i = range1; i <= range2; i++)
                                    Console.WriteLine(FileHelper.MovieList[i - 1].Display());
                                break;
                            }
                            case 2:
                            {
                                logger.Trace("User chose to add movie");
                                var genresPicked = new List<string>();
                                var id = FileHelper.MovieList.Last().Id + 1;
                                Console.WriteLine("What is the title of the film?");
                                var title = Console.ReadLine();
                                Console.WriteLine("What year was the movie made in?");
                                title = title + " (" + Console.ReadLine() + ")";
                                while (DuplicateChecker(title, "Movie"))
                                {
                                    Console.WriteLine("The film you picked already exists in enter a new one");
                                    title = Console.ReadLine();
                                    Console.WriteLine("Enter the year of the film");
                                    title = title + " (" + Console.ReadLine() + ")";
                                }

                                Console.WriteLine("How many genres do you want to add?");
                                var genreAmount = Menu.ValueGetter();
                                var genres = new List<string>();
                                for (var i = 0; i < genreAmount; i++)
                                {
                                    Console.WriteLine($"What is the {i + 1} genre?");
                                    genres.Add(Console.ReadLine());
                                }

                                FileHelper.MovieAdd(id, title, genres);
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
                        FileHelper.Shows(); //reads the videos file and makes the list for it in the CSVFile Class
                        switch (choice)
                        {
                            case 1:
                            {
                                Console.WriteLine($"Range number 1 (1-{FileHelper.ShowsList.Count})");
                                var range1 = Menu.ValueGetter();
                                while (range1 > FileHelper.ShowsList.Count || range1 <= 0)
                                {
                                    Console.WriteLine($"Enter new number (1-{FileHelper.ShowsList.Count})\n");
                                    range1 = Menu.ValueGetter();
                                }

                                Console.WriteLine($"Enter new number from ({range1}-{FileHelper.ShowsList.Count})");
                                var range2 = Menu.ValueGetter();
                                while (range2 < range1 || range2 > FileHelper.ShowsList.Count)
                                {
                                    Console.WriteLine(
                                        $"Invalid Number\nRange number 2 ({range1}-{FileHelper.ShowsList.Count})");
                                    range2 = Menu.ValueGetter();
                                }

                                for (var i = range1; i <= range2; i++)
                                    Console.WriteLine(FileHelper.ShowsList[i - 1].Display());
                                break;
                            }
                            case 2:
                            {
                                logger.Trace("User chose to add show");
                                var writers = new List<string>();
                                var id = FileHelper.ShowsList.Last().Id + 1;
                                Console.WriteLine("What is the title of the show?");
                                var title = Console.ReadLine();
                                while (DuplicateChecker(title, "Show"))
                                {
                                    Console.WriteLine("That show already exists try another");
                                    title = Console.ReadLine();
                                }

                                Console.WriteLine("How many seasons are in the show?");
                                var seasons = Menu.ValueGetter();
                                Console.WriteLine("How many episodes?");
                                var episodes = Menu.ValueGetter();
                                Console.WriteLine("How many writers are there?");
                                var writerCount = Menu.ValueGetter();
                                for (var i = 0; i < writerCount; i++)
                                {
                                    Console.WriteLine($"What is the name of writer #{i + 1}");
                                    writers.Add(Console.ReadLine());
                                }

                                FileHelper.ShowAdd(id, title, seasons, episodes, writers);
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
                        FileHelper.Videos(); //reads the videos file and makes the list for it in the CSVFile Class
                        switch (choice)
                        {
                            case 1:
                            {
                                Console.WriteLine($"Range number 1 (1-{FileHelper.VideoList.Count})");
                                var range1 = Menu.ValueGetter();
                                while (range1 > FileHelper.VideoList.Count || range1 <= 0)
                                {
                                    Console.WriteLine(
                                        $"Invalid Number!\nEnter new number (1-{FileHelper.VideoList.Count})");
                                    range1 = Menu.ValueGetter();
                                }

                                Console.WriteLine($"Range number 2 ({range1}-{FileHelper.VideoList.Count})");
                                var range2 = Menu.ValueGetter();
                                while (range2 < range1 || range2 > FileHelper.VideoList.Count)
                                {
                                    Console.WriteLine(
                                        $"Invalid Number\nEnter new number from ({range1}-{FileHelper.VideoList.Count})");
                                    range2 = Menu.ValueGetter();
                                }

                                for (var i = range1; i <= range2; i++)
                                    Console.WriteLine(FileHelper.VideoList[i - 1].Display());
                                break;
                            }
                            case 2:
                            {
                                logger.Trace("User chose to add a video");
                                var regions = new List<int>();
                                var formats = new List<string>();
                                var id = FileHelper.VideoList == null ? 1 : FileHelper.VideoList.Last().Id + 1;
                                Console.WriteLine("What is the title of the video?");
                                var title = Console.ReadLine();
                                while (DuplicateChecker(title, "Video"))
                                {
                                    Console.WriteLine("This Video already exists enter a new title");
                                    title = Console.ReadLine();
                                }

                                Console.WriteLine("How many formats is the video on?");
                                var formatTotals = Menu.ValueGetter();
                                for (var i = 0; i < formatTotals; i++)
                                {
                                    Console.WriteLine($"Format #{i + 1}");
                                    formats.Add(Console.ReadLine());
                                }

                                Console.WriteLine("How many minutes long is the video?");
                                var length = Menu.ValueGetter();
                                Console.WriteLine("How many regions is it in?");
                                var regionsCount = Menu.ValueGetter();
                                for (var i = 0;
                                    i < regionsCount;
                                    i++) //I don't know the region codes so I made them on the spot
                                {
                                    Console.WriteLine($"Region #{i + 1}?");
                                    Console.WriteLine(
                                        "0.)North America\n1.)South America\n2.)Europe\n3.)Asia\n4.)Australia\n5.)Antarctica");
                                    regions.Add(Menu.ValueGetter());
                                }

                                FileHelper.VideoAdd(id, title, formats, length, regions);
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
                        Console.WriteLine("What do you want to search from all Media?");
                        FileHelper.SearchMedia(Console.ReadLine());
                        break;
                    case 5:
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
            var contained = false;
            switch (type)
            {
                case "Movie":
                    foreach (var media in FileHelper.MovieList)
                        if (media.title.ToLower().Equals(chosenMedia.ToLower()))
                        {
                            contained = true;
                            break;
                        }

                    break;
                case "Show":
                    foreach (var media in FileHelper.MovieList)
                        if (media.title == chosenMedia)
                        {
                            contained = true;
                            break;
                        }

                    break;
                case "Video":
                    foreach (var media in FileHelper.VideoList)
                        if (media.title == chosenMedia)
                        {
                            contained = true;
                            break;
                        }

                    break;
            }

            return contained;
        }
    }
}