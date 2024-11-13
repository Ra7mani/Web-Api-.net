using test_api.Model.Domaine.Entities;

namespace test_api.Model.Interfaces
{
    public interface ITokenManager
    {
        bool Authenticate(string user, string pwd);
        Token NewToken();
        bool VerifyToken(String token);
    }
}
