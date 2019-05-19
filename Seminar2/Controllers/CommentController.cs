using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seminar2.Services;
using Seminar2.ViewModel;

namespace Seminar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService commentService;

        public CommentsController(ICommentService service)
        {
            this.commentService = service;
        }
        /// <summary>
        /// gets all comments
        /// </summary>
        /// <param name="text"> filter by text</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CommentListDto> GetComments(string text)
        {
            return commentService.GetComments(text);
        }
    }
}