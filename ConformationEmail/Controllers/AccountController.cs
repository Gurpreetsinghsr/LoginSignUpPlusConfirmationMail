using ConformationEmail.Models;
using ConformationEmail.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ConformationEmail.Controllers
{
    public class AccountController : Controller
    {
        public readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel, string returnUrl)
        {
            if(ModelState.IsValid)
            {
               var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                       
                        return LocalRedirect(returnUrl); 
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid");
            }
            return View(signInModel);
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);

                    }
                    return View(userModel);
                }
                ModelState.Clear();
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token)
        {
           

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _accountRepository.ConfirmEmailAsync(uid, token);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                }
            }

            return View();
        }


    }
}
