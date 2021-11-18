using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace ECommerceApp.Services.Identity
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);
        Task<UserDto> Authenticate(LoginData data);
        Task<UserDto> GetUser(ClaimsPrincipal user);
        Task Logout();
        string GetUserId();
    }

    public class IdentityUserService : IUserService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        readonly IEmailService emailService;

        public IdentityUserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<IdentityUserService> logger, IHttpContextAccessor httpContextAccessor, IEmailService emailService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            Logger = logger;
            this.httpContextAccessor = httpContextAccessor;
            this.emailService = emailService;
        }

        public string GetUserId()
        {
            var principal = httpContextAccessor.HttpContext.User;
            return userManager.GetUserId(principal);
        }

        public ILogger<IdentityUserService> Logger { get; }

        public async Task<UserDto> Authenticate(LoginData data)
        {
            var user = await userManager.FindByNameAsync(data.Username);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                await signInManager.SignInAsync(user, false);
                return await CreateUserDto(user);
            }

            Logger.LogInformation("Invalid login for username '{Username}'", data.Username);
            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if (user == null) return null;

            return await CreateUserDto(user);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new IdentityUser
            {
                Email = data.Email,
                UserName = data.Username,
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                if (data.MakeMeAnAdmin)
                    await userManager.AddToRoleAsync(user, "Administrator");

                if (data.MakeMeAnEditor)
                    await userManager.AddToRoleAsync(user, "Editor");

                await emailService.SendEmail(
                    data.Email,
                    "Welcome to Golf Land",
                    "Welcome!",
                    "<div>Hello!! You are now a registered user with Golf Land. Head back to our site to start shopping for the latest and greatest golf equipment!</div>");

                await signInManager.SignInAsync(user, false);
                return await CreateUserDto(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private async Task<UserDto> CreateUserDto(IdentityUser user)
        {
            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
            };
        }
    }
}
