using Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(int userId, EUserRole role);
        string ComputeSha256Hash(string password);
    }
}
