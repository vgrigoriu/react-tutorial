﻿using System.Web.Http;

namespace Comments.Controllers
{
    public class CommentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new[]
            {
                new {id = 1, author = "vasile",  text = "vasile dixit"},
                new {id = 2, author = "horia",  text = "horia vorbește _apăsat_"}
            });
        }
    }
}
