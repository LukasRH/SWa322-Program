﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    class MovieMenuItem : MenuItemBase
    {
        public readonly int MovieId;
        private readonly string _releaseDate;
        private readonly double _rating;
        private readonly int _duration;
        public readonly string Genre;
        private readonly string _resume;
        public readonly string Director;
        public readonly List<string> Actors;
        public string UserRating;

        public MovieMenuItem(int movieId, string title, string releaseDate, double rating, int duration, string genre, string resume, string director, List<string> actors) : base(title)
        {
            this.MovieId = movieId;
            this._releaseDate = releaseDate;
            this._rating = rating;
            this._duration = duration;
            this.Genre = genre;
            this._resume = resume;
            this.Director = director;
            this.Actors = actors;
            this.UserRating = MySqlCommands.FindRatingFromMovieId(MovieId);
        }
        
        public override void Select()
        {
            UserRating = MySqlCommands.FindRatingFromMovieId(MovieId);

            Console.Clear();

            Console.WriteLine($"{Title}   {_releaseDate}");
            Console.WriteLine($"{Genre}");
            Console.WriteLine($"");
            Console.WriteLine($"Duration: {_duration} min");
            Console.WriteLine($"{_resume}");
            Console.WriteLine($"Director: {Director}.");
            Console.WriteLine("\nLeading actors");

            foreach (var actor in Actors)
            {
                Console.WriteLine(actor);
            }
                        
            if (UserRating != "notRated")
            {
                PrintStringColoredInLine($"\nYou have rated this movie: ", ConsoleColor.Magenta);
                if (UserRating == "thumbsup")
                    PrintStringColored("thumbs up", ConsoleColor.Green);
                else if (UserRating == "thumbsdown")
                    PrintStringColored("thumbs down", ConsoleColor.Red);
                Console.WriteLine($"\nothers have rated this movie {_rating } on IMDB");
            }
            else
            {
                Console.WriteLine(); // new line for style
            }
            
            RateMovieMenu rateMenu = new RateMovieMenu("Rate this movie", MovieId);
            User.UpdateUser();

            rateMenu.Start();
        }
    }
}
