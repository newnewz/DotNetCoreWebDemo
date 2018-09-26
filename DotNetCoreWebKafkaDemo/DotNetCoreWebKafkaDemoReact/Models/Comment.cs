using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebKafkaDemoReact.Models
{
    public class Comment
    {
        public Comment(string message)
        {
            Id = 0;
            Author = "";
            Text = message;
        }
        public Comment()
        { }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }

    public static class CommentListExtension
    {
        public static void AddComment(this IList<Comment> str, string message)
        {
            var newComment = new Comment(message);
            str.Add(newComment);
        }
    }
}
