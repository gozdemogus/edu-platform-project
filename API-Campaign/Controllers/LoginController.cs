using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using APICampaign.JWT;
using APICampaign.JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICampaign.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuth _jwtAuth;

       
        public LoginController(IJwtAuth jwtAuth)
        {
            _jwtAuth = jwtAuth;
        }
      
        [AllowAnonymous]
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }


    }
}

//The authentication method took the user name and password from the body.
//Pass credential to the jwtAuth. Authentication method to get token.
//Return token.
//Add attributes [AllowAnonymous] as this method can be handled by any user.
//Add [Authorize] attributes to controller.
//Add “jwtAuth” in the constructor.