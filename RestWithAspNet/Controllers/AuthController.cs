using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Business;
using RestWithAspNet.Data.VO;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if(user == null) return BadRequest("Invalid client request!");

            var token = _loginBusiness.ValidateCredentials(user);

            if(token == null) return Unauthorized();

            return Ok(token);
        }
    }
}
