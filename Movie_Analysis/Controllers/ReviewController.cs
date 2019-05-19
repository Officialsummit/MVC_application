using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Analysis.Data;
using Movie_Analysis.Models;
using Movie_Analysis.Models.AccountViewModels;
using Movie_Analysis.Models.MovieReviewModel;

namespace Movie_Analysis.Controllers
{
    public class ReviewController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ReviewController (ApplicationDbContext context)
        {
            _context = context;
        }
       


        public async Task<IActionResult> ReviewDetails(int? id)
        {
            ViewBag.Movie = await _context.Movie.FirstAsync(m => m.Id == id);
            ViewBag.MovieId = id;
            ViewBag.Name = this.User.FindFirstValue(ClaimTypes.Name);
            ViewBag.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await _context.Review.Include(r=>r.User).Where(r=>r.MovieId==id).ToListAsync());
        }

        public async Task<IActionResult> EditReview(int? id)
        {
           if(id==null)
            {
                return NotFound();
            }
            var reviewEdit = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);
            if(reviewEdit==null)
            {
                return NotFound();
            }
            

            return View(reviewEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>EditReview(int id, MovieReviewModel review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    review.ModifiedDate = DateTime.Now;
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewDetailsExist(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }
        private bool ReviewDetailsExist(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
        public IActionResult Index()
        {
            return View();
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveReview(int movieId, string review,float rate)
        {
            MovieReviewModel movieReviewModel = new MovieReviewModel();
            

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            movieReviewModel.UserId = userId;
            movieReviewModel.Rating = rate;
            movieReviewModel.MovieId = movieId;
            movieReviewModel.Review = review;
            movieReviewModel.CreatedDate = DateTime.Now;
            movieReviewModel.ModifiedDate = DateTime.Now;
           

            _context.Add(movieReviewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ReviewDetails), new { @id = movieId });
        }
      
       

    }
}