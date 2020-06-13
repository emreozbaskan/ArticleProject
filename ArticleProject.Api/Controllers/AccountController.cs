using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{
    using Entities.DTOS;
    using BL.Abstract;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAutService _AutService;
        public AccountController(IAutService autService)
        {
            this._AutService = autService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDTO userForLoginDTO)
        {
            var myUserToLogin = _AutService.Login(userForLoginDTO);
            if (!myUserToLogin.Success)
                return BadRequest(myUserToLogin.Message);
            var myResult = _AutService.CreateAccessToken(myUserToLogin.Data);
            if (!myResult.Success)
                return BadRequest(myResult.Message);

            return Ok(myResult.Data);
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDTO userForRegisterDTO)
        {
            var myUserExits = _AutService.UserExists(userForRegisterDTO.Email);
            if (!myUserExits.Success)
                return BadRequest(myUserExits.Message);

            var myResult = _AutService.Register(userForRegisterDTO, userForRegisterDTO.Password);
            if (!myResult.Success)
                return BadRequest(myResult.Message);

            var myAccessToken = _AutService.CreateAccessToken(myResult.Data);
            if (!myAccessToken.Success)
                return BadRequest(myAccessToken.Message);

            return Ok(myAccessToken.Data);
        }
    }
}
