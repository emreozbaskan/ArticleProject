using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{
    using Entities.DTOS;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDTO)
        {
            return Ok(true);
        }
    }
}
