using ggsport.Authentication.Model.Dto;
using ggsport.Authentication.Model.Entity;

namespace ggsport.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task ConfirmEmail(UserModel user);
        Task<UserModel?> GetUser(string email);
        Task<bool> IsExist(UserModel model);
        string? Login(UserModel? user, LoginModel model);
        string Register(UserModel model);
    }
}