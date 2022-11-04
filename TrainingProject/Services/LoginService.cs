using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TrainingProject.Entities;
using TrainingProject.Interface;
using TrainingProject.Models;

namespace TrainingProject.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginService(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Register(LoginModels loginModels)
        {
            var isUser = await _userManager.FindByEmailAsync(loginModels.Email);
            if(isUser != null) return;

            var user = new IdentityUser { UserName = loginModels.Email, Email = loginModels.Email };
            var result = await _userManager.CreateAsync(user, loginModels.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
            }
        }
    }
}
