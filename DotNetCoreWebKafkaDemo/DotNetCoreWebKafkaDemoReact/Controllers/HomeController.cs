using DotNetCoreWebKafkaDemoReact.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCoreWebKafkaDemoReact.Controllers
{
    public class HomeController : Controller
    {
        private static IList<Comment> _comments;

        static HomeController()
        {

            _comments = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Author = "",
                    Text = "kafka and react"
                }
            };

        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }

        [Route("comments/newMessage")]
        [HttpPost]
        public ActionResult AddMessage([FromBody] string message)
        {
            // Create a fake ID for this comment
            var newComment = new Comment();
            newComment.Id = _comments.Count + 1;
            newComment.Author = "";
            newComment.Text = message ?? "it was null " + newComment.Id;
            _comments.Add(newComment);
            return Content("Success :)");
        }
    }
}
