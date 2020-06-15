using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{
    using ArticleProject.Entities.Concrete;
    using BL.Abstract;

    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("Add")]
        public ActionResult Add(Article article)
        {
            var myResult = _articleService.Add(article);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Article article)
        {
            var myResult = _articleService.Update(article);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Article article)
        {
            var myResult = _articleService.Delete(article);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int Id)
        {
            var myResult = _articleService.GetById(Id);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("GetList")]
        public IActionResult GetList(int skip, int take)
        {
            var myResult = _articleService.GetList(skip, take);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("Search")]
        public IActionResult Search(string search, int skip = 0, int take = 10)
        {
            var myResult = _articleService.GetSearch(search, skip, take);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }
    }
}
