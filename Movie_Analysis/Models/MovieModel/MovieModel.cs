using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Analysis.Models.MovieModel
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String Language { get; set; }
        public int Duration { get; set; }
        public String Budget { get; set; }
        public double IMDBScore { get; set; }
        public String Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
