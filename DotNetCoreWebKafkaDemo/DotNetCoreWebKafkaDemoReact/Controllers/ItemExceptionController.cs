using DotNetCoreWebKafkaDemoReact.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebKafkaDemoReact.Controllers
{
    public class ItemExceptionController : Controller
    {
        private static IList<Comment> _comments;

        public ActionResult Index()
        {
            return View();
        }

        [Route("ItemExceptions")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("ItemExceptions/new")]
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }

        [Route("ItemExceptions/newMessage")]
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
