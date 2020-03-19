using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    class Movie
    {
        private int id;
        private string title;
        private int releaseDate;
        private string genre;
        private string description;

        public int MovieID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Movie(int id, string title, int releaseDate, string genre, string description)
        {
            this.MovieID = id;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Genre = genre;
            this.Description = description;
        }
        public Movie(string title)
        {
            this.Title = title;
        }
    }
}
