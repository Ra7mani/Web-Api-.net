using test_api.Model.Domaine.Entities;

namespace test_api.Model.Interfaces
{
    public interface IJWTTokenManager
    {
        bool Authenticate(string user, string pwd);
        string NewToken();
        bool VerifyToken(String token);
    }
}
