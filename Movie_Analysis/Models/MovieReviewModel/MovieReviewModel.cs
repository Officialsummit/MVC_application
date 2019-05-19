using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Analysis.Models.MovieReviewModel
{
    public class MovieReviewModel
    {
        public int Id { get; set; }       
        public int MovieId { get; set; }       
        public string UserId { get; set; }       
        public string Review{ get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ApplicationUser User { get; set; }
    }
}
