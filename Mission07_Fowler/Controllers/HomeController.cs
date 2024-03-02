using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission07_Fowler.Models;
using System.Diagnostics;

namespace Mission07_Fowler.Controllers
{
    // Defines a class named HomeController that inherits from the Controller class
    public class HomeController : Controller
    {
        // Holds an instance of the database context class
        private Context _context;

        //Constructor for the HomeController class that receives a parameter of type Context. Typically called once per request.
        public HomeController(Context temp)
        {
            _context = temp;
        }

        public IActionResult Index() // IActionResult is a type defines what should be returned. Allows for returning views, etc.
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm() // .Categories and Movies is referring to the DbSet<> not the table
        {
            ViewBag.Categories = _context.Categories   //Creates bag of category names
                .OrderBy(x => x.CategoryName).ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid) //If not valid, returns to MovieForm with their data so they can fix it
            {
                _context.Movies.Add(response); // Adds response into the database and saves changes
                _context.SaveChanges();
                return View("Index");
            }

            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Title = "Error";
                return View(response);
            }
        }

        public IActionResult ViewMovies()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            // Fetches all movies including related category information
            var movies = _context.Movies
                .Include(x => x.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var recordEdit = _context.Movies
                .SingleOrDefault(x => x.MovieId == id); //I got an error when I used .Single, but using .SingleOrDefault fixed it

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie updated)
        {
            _context.Update(updated);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies"); //Returns to movie list via the ViewMovies action
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordDelete = _context.Movies
                .Single(x => x.MovieId == id); /*This is where I get the error. It runs through this loop twice for some reason. The first time it 
                                               successfully store the record, but the second time it returns recordDelete as null. However if you
                                               press continue on the error message, it will still navigate to the delete page and allow you to 
                                               delete the record. Nate Buck TA and several classmates could not figure it out.*/

            return View(recordDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deleteRecord)
        {
            _context.Movies.Remove(deleteRecord);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}