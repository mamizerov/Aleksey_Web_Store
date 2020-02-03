using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Entities.Base;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false); //Проверяем логин/пароль пользователя

            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Вход невозможен");//говорим пользователю что вход невозможен
                return View(model);
            }

            if (Url.IsLocalUrl(model.ReturnUrl)) //если returnUrl - локальный
            {
                return Redirect(model.ReturnUrl); //перенаправляем туда, откуда пришли
            }

            return RedirectToAction("Index", "Home"); //иначе на главную
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User { UserName = model.UserName, Email = model.Email };
            var createResult = await _userManager.CreateAsync(user, model.Password);

            if (!createResult.Succeeded)
            {
                foreach (var identityError in createResult.Errors) //выводим ошибки
                {
                    ModelState.AddModelError("", identityError.Description);
                    return View(model);
                }
            }

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
    }
}