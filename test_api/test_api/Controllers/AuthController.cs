using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_api.Model.Interfaces;

namespace test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("new-token")]
        public IActionResult NewToken()
        {
            var token = _tokenService.GenerateToken();
            return Ok(new { token });
        }

        [HttpGet("verify-token")]
        public IActionResult VerifyToken(string token)
        {
            var isValid = _tokenService.VerifyToken(token);
            return Ok(new { isValid });
        }
    }
}
