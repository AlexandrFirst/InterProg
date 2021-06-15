using System.Threading.Tasks;
using InterProgApi.Data;

namespace InterProgApi.Core
{
    public interface IUserService
    {
         Task<User> GetUserByMailPass(string mail, string pass);
    }
}