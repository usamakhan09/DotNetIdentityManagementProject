using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSIdentity.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    //[Authorize]
    public class TestController : ControllerBase
    {
        //[Authorize]
        [HttpGet]
        public IActionResult VerifyUser()
        {
         
            if (User.Identity!.IsAuthenticated)
            {
                var response = new
                {
                    status = 200,
                    message = "Verified User"
                };
                return Ok(response);
            }
            else
            {
                var response = new
                {
                    status = 401,
                    message = "Unauthorized User"
                };
                return StatusCode(StatusCodes.Status401Unauthorized, response);
            }
        }
        //[HttpGet]
        //public IActionResult Unauthorized()
        //{
        //    var response = new
        //    {
        //        status = 401,
        //        error = "Unauthorized"
        //    };
        //    return StatusCode(StatusCodes.Status401Unauthorized, response);
        //}

    }
}
