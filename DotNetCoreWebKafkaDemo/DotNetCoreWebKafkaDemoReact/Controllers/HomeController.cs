using DotNetCoreWebKafkaDemoReact.Models;
using KafkaData.Consumers;
using KafkaData.Interfaces;
using KafkaData.Producers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCoreWebKafkaDemoReact.Controllers
{
    public class HomeController : Controller
    {
        private ITopicProducer _topicProducer;
        private ITopicConsumer _topicConsumer;

        private static IList<string> _messages;

        HomeController()
        {
            _topicConsumer = new KafkaTopicConsumer("test");
            _topicProducer = new KafkaTopicProducer("test");
            _messages = new List<string>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_messages);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            // Create a fake ID for this comment
            //comment.Id = _comments.Count + 1;
            //_comments.Add(comment);
            return Content("Success :)");
        }
    }
}
