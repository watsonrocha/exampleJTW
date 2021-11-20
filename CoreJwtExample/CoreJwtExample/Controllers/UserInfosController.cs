using CoreJwtExample.IService;
using CoreJwtExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJwtExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private IUserinfoService _userInfoService;
        public UserInfosController(IUserinfoService userinfoService)
        {
            _userInfoService = userinfoService;
        }

        //Post : api/UserInfos/Authenticate
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userInfoService.Authenticate(model.Username, model.Password);
            if (user == null) return BadRequest(new { message = "Username and password incorrect" });
            return Ok(user);
        }

        //Get : api/UserInfos
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }
       
    }
}
