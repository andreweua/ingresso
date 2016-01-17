using Ingresso.Identity.Classes;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ingresso.Web.Controllers
{
    public class ManageController : Controller
    {
        #region Privados

        private const string _msgChangePasswordSuccess = "Senha alterada com sucesso!";

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion

        #region Protegidos

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Públicos

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Alteração de Senha

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userManager.ChangePasswordAsync(
                User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }

                return RedirectToAction("ChangePasswordConfirmation");
            }

            this.AddErrors(result);

            return View(model);
        }

        //
        // GET: /Manage/ChangePasswordConfirmation
        public ActionResult ChangePasswordConfirmation()
        {
            return View();
        }

        #endregion

        #endregion
    }
}
