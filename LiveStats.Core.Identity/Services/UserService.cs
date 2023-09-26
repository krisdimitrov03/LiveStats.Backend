using LiveStats.Core.Identity.Contracts;
using LiveStats.Core.Identity.Data.Models.Input;
using LiveStats.Core.Identity.Data.Settings;
using LiveStats.Core.Identity.Extensions;
using LiveStats.Infrastructure.Data.Models.Identity;
using LiveStats.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LiveStats.Core.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IUserEmailStore<ApplicationUser> emailStore;
        private readonly IJwtService jwtService;
        private readonly JwtSettings jwtSettings;

        public UserService(
            IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IUserStore<ApplicationUser> _userStore,
            IJwtService _jwtService,
            IOptions<JwtSettings> _jwtSettings)
        {
            this.repo = _repo;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.userStore = _userStore;
            this.emailStore = GetEmailStore();
            this.jwtService = _jwtService;
            this.jwtSettings = _jwtSettings.Value;
        }

        public async Task<(bool, string?)> LogUserIn(LoginModel data)
        {
            try
            {
                var result = await signInManager
                    .PasswordSignInAsync(data.Username, data.Password, false, false);

                if (!result.Succeeded)
                    throw new Exception();

                var user = await userManager.FindByNameAsync(data.Username);
                var roles = await userManager.GetRolesAsync(user);

                var tokenData = new TokenData
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Roles = string.Join(", ", roles),
                    ImageUrl = user.ImageUrl
                };

                var token = jwtService.GenerateToken(tokenData, jwtSettings);

                return (true, token);
            }
            catch (Exception)
            {
                return (false, null);
            }
        }

        public async Task<(bool, Dictionary<string, List<string>>?)> RegisterUser(RegisterModel data)
        {
            try
            {
                var user = Activator.CreateInstance<ApplicationUser>();

                await userStore.SetUserNameAsync(user, data.Username, CancellationToken.None);
                await emailStore.SetEmailAsync(user, data.Email, CancellationToken.None);

                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                var result = await userManager.CreateAsync(user, data.Password);

                if (result.Succeeded)
                    return (true, null);

                var errors = result.Errors
                    .Select(e => e.Description)
                    .GroupByFirstWord();

                return (false, errors);
            }
            catch (Exception)
            {
                return (false, null);
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)userStore;
        }
    }
}
