using NTier.Model.Model.Entities;
using NTier.Service.Service.Base;


namespace NTier.Service.Service.Option
{
    public class AppUserService : BaseService<AppUser>
    {
        public bool CheckCredentials(string userName, string password) => Any(user => user.UserName == userName && user.Password == password);

        public AppUser FindByUserName(string userName) => GetByDefault(user => user.UserName == userName);
    }
}
