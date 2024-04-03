using Developer_book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developer_book.Controllers
{
    public class PostsController : Controller
    {
        // GET: /Posts
        public IActionResult Index()
        {
            return View();
        }

        // Action for adding a post
        [HttpPost]
        public IActionResult AddPost(Posts post)
        {
            if (ModelState.IsValid)
            {
                // Create an instance of your model
                Posts postsModel = new Posts();

                // Call the method to insert data into the database
                postsModel.AddPost(post);

                // Redirect to the Index action after successfully adding the post
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return to the same view with validation errors
            return View("Index", post);
        }
    }
}
