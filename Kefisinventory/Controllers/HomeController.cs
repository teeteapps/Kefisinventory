using DBL;
using DBL.Models;
using Kefisinventory.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kefisinventory.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly BL bl;
        public HomeController()
        {
            bl = new BL(Util.GetDbConnString());
        }
       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Loginviewmodel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var resp = await bl.Login(model.Emailaddress, model.Password);
                if (resp.RespStatus == 0)
                {
                    UserModel User = new UserModel();

                    User.Usercode = resp.Usercode;
                    User.Email = resp.Email;
                    User.Fullname = resp.Fullname;
                    User.profilecode = resp.profilecode;
                             
                    SetUserLoggedIn(User, false);
                    return RedirectToLocal(returnUrl);
                }
                else if (resp.RespStatus == 1)
                {
                    Danger(resp.RespMessage, true);
                }
                else
                {
                    Danger("Database Error Occured. Contact Admin!", true);
                }
            }
            return View(new Loginviewmodel());
        }

        private async void SetUserLoggedIn(UserModel user, bool rememberMe)
        {
            UserDataModel serializeModel = new UserDataModel
            {
                UserCode = user.Usercode,
                ShopName = user.Fullname
            };

            string userData = JsonConvert.SerializeObject(serializeModel);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Usercode.ToString()),
                new Claim(ClaimTypes.Name, user.Fullname),
                 new Claim("FullNames", serializeModel.ShopName),
                new Claim("userData", userData),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Login), "Home");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Dashboard), "Home");
            }
        }
    }
}
