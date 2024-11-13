using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_api.Model.Interfaces;
using test_api.Model.Service;

namespace test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTAuthentificationController : ControllerBase
    {
        private IJWTTokenManager tokenManager;

        public JWTAuthentificationController(IJWTTokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        [HttpPost]
        public IActionResult Authenticate(string user, string pwd)
        {
            if (tokenManager.Authenticate(user, pwd))
                return Ok(tokenManager.NewToken());
            else
                ModelState.AddModelError("Unauthorised", "you are not authorized");
            return BadRequest();
        }
    }
}
