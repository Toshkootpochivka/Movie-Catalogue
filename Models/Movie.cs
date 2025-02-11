﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Database.Models
{
    public class Movie
    {
        public static int COUNT_OF_SYMBOLS_PER_LINE = 52;

        public int Id { get; set; }
        public string Title { get; set; }   
        public string Director { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Summary { get; set; }

        public Movie(int id, string title, string director, string date, string genre, string summary)
        {
            this.Id = id;
            this.Title = title;
            this.Director = director;
            this.Date = date;
            this.Genre = genre;
            this.Summary = summary;
        }

        public Movie(int id, string title, string director, string date, string genre) {
            this.Id = id;
            this.Title = title;
            this.Director = director;
            this.Date = date;
            this.Genre = genre;
            this.Summary = string.Empty;
        }

        public override string ToString()
        {
            if (this.Summary == "None")
            {
                return $"{this.Id}. {this.Title} ({this.Date})\n" +
                       $"Director: {this.Director}\n" +
                       $"   Genre: {this.Genre}\n\n" +
                       $"There is no given information for the movie";
            }

            string summary = "";
            bool is_time = false;
            int count = 0;
            for(int i = 0; i < this.Summary.Length; i++)
            {
                summary += this.Summary[i];

                if (count == COUNT_OF_SYMBOLS_PER_LINE) is_time = true;

                if(is_time && this.Summary[i] == ' ')
                {
                    summary += "\n  ";
                    count = 0;
                    is_time = false;
                }
                
                count++;
            }

            return $"{this.Id}. {this.Title} ({this.Date})\n" +
                   $"Director: {this.Director}\n" +
                   $"   Genre: {this.Genre}\n\n" +
                   $"The movie is about:\n  {summary}";
        }
    }
}
