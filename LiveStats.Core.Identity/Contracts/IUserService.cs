using LiveStats.Core.Identity.Data.Models.Input;

namespace LiveStats.Core.Identity.Contracts
{
    public interface IUserService
    {
        Task<(bool, string?)> LogUserIn(LoginModel data);
        Task<(bool, Dictionary<string, List<string>>?)> RegisterUser(RegisterModel data);
    }
}
