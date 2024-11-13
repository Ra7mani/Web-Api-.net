using test_api.Model.Domaine.Entities;
using test_api.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace test_api.Model.Service
{
    public class TokenManager : ITokenManager
    {
        private List<Token> _tokens;

        public TokenManager()
        {
            _tokens = new List<Token>();
        }

        public bool Authenticate(string user, string pwd)
        {
            return user == "admin" && pwd == "password";
        }

        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMinutes(2)
            };
            _tokens.Add(token);
            return token;
        }

        public bool VerifyToken(string token)
        {
            return _tokens.Any(x => x.Value == token && x.ExpiryDate > DateTime.Now);
        }
    }
}
