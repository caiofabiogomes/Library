using Library.Core.Enums;

namespace Library.Infra.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(int userId, EUserRole role);
        string ComputeSha256Hash(string password);
    }
}
