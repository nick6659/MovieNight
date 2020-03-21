using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("MovieNight\n");
                Console.Write("1) Søg efter film \n2) Søg efter skuespiller \n3) Søg på genre \n4) FilmMenu \n5) SkuespillerMenu \n6) Luk \n\nDu har valgt: ");
                if (!int.TryParse(Console.ReadLine(), out int input1))
                {
                    Console.WriteLine("Prøv venligst igen!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input1)
                {
                    case 1:
                        Console.Clear();
                        SearchMovie();
                        break;

                    case 2:
                        Console.Clear();
                        SearchActor();
                        break;

                    case 3:
                        Console.Clear();
                        SearchGenre();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("1) Tilføj film \n2) Rediger film \n3) Slet film \n6) Luk \n\nDu har valgt: ");
                        Console.ReadLine();
                        if (!int.TryParse(Console.ReadLine(), out int input2))
                        {
                            Console.WriteLine("Prøv venligst igen!");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        switch (input2)
                        {
                            case 1:

                                Console.Clear();
                                Console.Write("Titel på filmen: ");
                                string title = Console.ReadLine();
                                Console.Write("Udgivelsesdato mm/dd/yyyy: ");
                                DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                                Console.Write("Genre: ");
                                string genre = Console.ReadLine();
                                Console.Write("Beskrivelse: ");
                                string description = Console.ReadLine();
                                InsertMovie(title, releaseDate, genre, description);
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:

                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nPrøv venligst igen! 1");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }
        }

        public static void SearchMovie()
        {
            Console.Write("Søg efter film: ");
            string searchMov = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFilm");
            Console.ResetColor();
            List<Movie> movie = MovieLibrary.MovieList(searchMov);
            foreach (Movie item in movie)
            {
                Console.WriteLine("Film titel: " + item.Title + "\nUdgivelsesår: " + item.ReleaseDate + "\nBeskrivelse: '" + item.Description + "'\n\n");
            }
            Console.WriteLine("Tryk på ENTER for at fortsætte..");
            Console.ReadKey();
            Console.Clear();
        }
        public static void SearchActor()
        {
            Console.Write("Søg efter skuespiller: ");
            string searchAct = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSkuespillere");
            Console.ResetColor();
            List<Actor> actor = ActorLibrary.ActorList(searchAct);
            foreach (Actor item in actor)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + "\n");
            }
            Console.WriteLine("Tryk på ENTER for at fortsætte..");
            Console.ReadKey();
            Console.Clear();
        }
        public static void SearchGenre()
        {
            Console.Write("Søg efter genre: ");
            string genre = Console.ReadLine();

            Console.WriteLine("\nFilm med genren: " + genre);
            List<Movie> movieByGenre = MovieLibrary.GenreMovieList(genre);
            foreach (Movie item in movieByGenre)
            {
                Console.WriteLine("\n" + item.Title);
            }
            Console.WriteLine("Tryk på ENTER for at fortsætte..");
            Console.ReadKey();
            Console.Clear();
        }
        public static Movie InsertMovie(string title, DateTime releaseDate, string genre, string description)
        {
            Movie m = new Movie(title, releaseDate, genre, description);
            return Dal.InsertMovie(m);
        }
    }
}