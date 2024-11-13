namespace test_api.Model.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken();
        bool VerifyToken(string token);
    }
}
