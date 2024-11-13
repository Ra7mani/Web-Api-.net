using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using test_api.Model.Domaine.Entities;
using test_api.Model.Interfaces;

namespace test_api.Model.Service
{
    public class JWTTokenManager : IJWTTokenManager
    {
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private byte[] _key;

        public JWTTokenManager()
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _key = Encoding.ASCII.GetBytes("12345678901234567890123456789012");
        }

        public bool Authenticate(string user, string pwd)
        {
            return user == "admin" && pwd == "password";
        }

        public string NewToken()
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Mohamed")
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            var tokenString = _jwtSecurityTokenHandler.WriteToken(token);
            return tokenString;
        }

        public bool VerifyToken(string token)
        {
            try
            {
                _jwtSecurityTokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_key),
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                return validatedToken != null;
            }
            catch
            {
                return false;
            }
        }

       
    }
}
