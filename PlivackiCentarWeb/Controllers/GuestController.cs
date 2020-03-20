using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DATA;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PlivackiCentarWeb.Models;
using PlivackiCentarWeb.Repositories;

namespace PlivackiCentarWeb.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public readonly IAccountRepository _accountRepository;

        public GuestController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AccountController()
        {
        }

        public void AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if(!Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                if (Session["current-account-role"]?.ToString() == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = _accountRepository.CheckLogin(model.Email, model.Password);

            if (account != null)
            {
                if(!account.IsTrener && !account.IsAdministrator && !account.IsPlivac && !account.IsRekreativac)
                {
                    ModelState.AddModelError("", "Korisnički nalog nema dodijeljenu rolu. Molimo Vas da nas kontaktirate.");
                    return View(model);
                }
                
                SignIn(account);

                if (Session["current-account-role"].ToString() == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Prijava neuspješna. Unijeli ste pogrešne podatke za prijavu.");
                return View(model);
            }
        }

        private void SignIn (Nalozi account)
        {
            try
            {
                ApplicationUser user = new ApplicationUser();
                user.nalogId = account.Id;
                user.Email = account.Email;

                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                List<Claim> claims = new List<Claim>();

                Claim nalogId = new Claim("nalogId", user.nalogId.ToString());
                claims.Add(nalogId);

                Claim schemaUsername = new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", user.Email);
                claims.Add(schemaUsername);

                Claim schemaUserId = new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", user.nalogId.ToString());
                claims.Add(schemaUserId);

                Claim schemaApp = new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Plivacki Centar NERETVA");
                claims.Add(schemaApp);

                ClaimsIdentity identity = new System.Security.Claims.ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);
                AuthenticationManager.SignIn(identity);

                Session["current-account-name"] = account.Ime + " " + account.Prezime;

                if (account.IsAdministrator)
                {
                    Session["current-account-role"] = "admin";
                }
                else if (account.IsPlivac)
                {
                    Session["current-account-role"] = "plivac";
                }
                else if (account.IsRekreativac)
                {
                    Session["current-account-role"] = "rekreativac";
                }
                else if (account.IsTrener)
                {
                    Session["current-account-role"] = "trener";
                }
            }
            catch (Exception)
            {
                RedirectToAction("LogOff", "guest");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", "Guest");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            if(!Request.IsAuthenticated)
                return View();
            else
            {
                if (Session["current-account-role"].ToString() == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nalog = _accountRepository.RegisterNewRekreativac(model);

                if(nalog != null)
                {
                    SignIn(nalog);

                    if (Session["current-account-role"].ToString() == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Registracija neuspješna. Provjerite podatke.");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Podaci za registraciju nisu ispravno unešeni.");
                return View(model);
            }
        }
       

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}