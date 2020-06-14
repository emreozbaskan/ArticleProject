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
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public ActionResult Add(Category category)
        {
            var myResult = _categoryService.Add(category);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Category category)
        {
            var myResult = _categoryService.Update(category);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Category category)
        {
            var myResult = _categoryService.Delete(category);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int Id)
        {
            var myResult = _categoryService.GetById(Id);
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var myResult = _categoryService.GetList();
            if (myResult.Success)
            {
                return Ok(myResult);
            }
            return BadRequest(myResult.Message);
        }
    }
}
