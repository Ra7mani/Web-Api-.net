using Microsoft.AspNetCore.Mvc;
using test_api.Model.Interfaces;
using test_api.Model.Service;
using test_api.Model.Domaine.Entities;

namespace test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly ITokenManager _tokenManager;

        public AuthentificationController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(string user, string pwd)
        {
            if (_tokenManager.Authenticate(user, pwd))
            {
                var token = _tokenManager.NewToken();
                return Ok(token);
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not authorized");
                return BadRequest(ModelState);
            }
        }
    }
}
