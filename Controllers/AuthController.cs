using ATSIdentity.Models;
using ATSIdentity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            var result = await _authService.RegisterUser(user);
            if (result.Succeeded)
            {
                var response = new
                {
                    status = 200,
                    message = "User successfuly created",
                };
                return Ok(response);
            }
            return BadRequest(result.Errors);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                var response = new
                {
                    status = 401,
                    message="Invalid Credentials"
                };
                return BadRequest(response);
            }
            var result = await _authService.Login(user);
            if (result)
            {

                var tokenString = _authService.GenerateTokenString(user);
                var response = new
                {
                    status=200,
                    token = tokenString
                };

                return Ok(response);
                //return Ok("done");
            }
            
            var response1 = new
            {
                status = 400,
                message = "incorrect password"
            };
            return BadRequest(response1);
        }
    }
}
