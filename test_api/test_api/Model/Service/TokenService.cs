using test_api.Model.Interfaces;

namespace test_api.Model.Service
{
    public class TokenService : ITokenService
    {
        private readonly Dictionary<string, DateTime> _tokens = new();
        private readonly TimeSpan _tokenLifetime = TimeSpan.FromHours(1); 

        public string GenerateToken()
        {
            var token = Guid.NewGuid().ToString();
            _tokens[token] = DateTime.UtcNow.Add(_tokenLifetime); 

            return token;
        }

        public bool VerifyToken(string token)
        {
            if (_tokens.TryGetValue(token, out var expiration))
            {
                if (DateTime.UtcNow <= expiration)
                {
                    return true;
                }
                else
                {
                    _tokens.Remove(token);
                }
            }

            return false;
        }
    }
}
