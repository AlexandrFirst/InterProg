using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace InterProgApi.helpers
{
    public class AuthOptions
    {
        const string KEY = "Super secret key";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}