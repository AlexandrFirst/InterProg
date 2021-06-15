using System.Threading.Tasks;
using InterProgApi.Core;
using InterProgApi.Data;
using InterProgApi.helpers;
using Microsoft.EntityFrameworkCore;

namespace InterProgApi.Service
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext context;

        public UserService(DatabaseContext context)
        {
            this.context = context;
        }


        public async Task<User> GetUserByMailPass(string mail, string pass)
        {
            var hashedPass = MyEncoder.ComputeSha256Hash(pass);

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == mail && u.Password == hashedPass);
            return user;
        }
    }
}