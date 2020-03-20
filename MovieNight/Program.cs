﻿using System;
using System.Collections.Generic;

namespace MovieNight
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("MovieNight\n");
                Console.Write("1) Søg efter film \n2) Søg efter skuespiller \n3) Søg på genre \n4) Exit \n\nDu har valgt: ");
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Prøv venligst igen!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
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
                        SearchByGenre();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nPrøv venligst igen!");
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
        public static void SearchByGenre()
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
    }
}