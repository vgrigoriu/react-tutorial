using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Comments.Controllers
{
    public class CommentsController : ApiController
    {
        private static ICollection<Comment> comments = new List<Comment>
        {
            new Comment("Castor", "un elefent se legăna"),
            new Comment("Polux", "podul de piatră s-a dărîmat"),
            new Comment("Romulus", "lorem ipsum dolorosa")
        };

        public IHttpActionResult Get()
        {
            return Ok(comments);
        }

        public IHttpActionResult Post(Comment comment)
        {
            comments.Add(comment);

            return Ok(comments);
        }
    }

    public class Comment
    {
        private static int currentId = 0;

        public int Id { get; } = currentId++;

        public string Author { get; }

        public string Text { get; }

        public Comment(string author, string text)
        {
            Author = author;
            Text = text;
        }
    }
}
