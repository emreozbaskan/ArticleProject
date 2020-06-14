using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleProject.BL.Abstract;
using ArticleProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("Add")]
        public ActionResult Add(Comment comment)
        {
            var myResult = _commentService.Add(comment);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Comment comment)
        {
            var myResult = _commentService.Update(comment);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Comment comment)
        {
            var myResult = _commentService.Delete(comment);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int Id)
        {
            var myResult = _commentService.GetById(Id);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("GetList")]
        public IActionResult GetList(int ArticleId)
        {
            var myResult = _commentService.GetList(ArticleId);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }
    }
}
