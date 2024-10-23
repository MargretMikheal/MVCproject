using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using MVCproject.Controllers;
using MVCproject.Models;
using MVCproject.ViewModels;
using System.Runtime.InteropServices;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> ManageAccount()
    {
        var userId = _userManager.GetUserId(User);
        var user = await _userManager.FindByIdAsync(userId);

        if(user == null)
            return NotFound();

   
           
        return View(user);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditAccount(ApplicationUser model,IFormFile profilePhoto)
    {
        var user = await _userManager.FindByIdAsync(model.Id);
        if(user == null) return NotFound();

        user.UserName = model.UserName;
        user.PhoneNumber = model.PhoneNumber;
        user.Address = model.Address;

        if(profilePhoto !=null && profilePhoto.Length>0)
        {
            using(var memoryStream = new MemoryStream())
            {
                await profilePhoto.CopyToAsync(memoryStream);
                user.ProfilePicture=memoryStream.ToArray();
            }
        }

        var result = await _userManager.UpdateAsync(user);
        if(result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }
    // GET: /Account/Login
    [HttpGet]
    public IActionResult Login()
    {
        LoginViewModel vm = new LoginViewModel();
        return View(vm);
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                bool found = await _userManager.CheckPasswordAsync(user, model.Password);
                if (found)
                {
                    await _signInManager.SignInAsync(user, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
            }
           
            
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            
        }
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var error in errors)
        {
            Console.WriteLine(error.ErrorMessage); // or use any logger to output this
        }
        return View(model);
    }

    // GET: /Account/Register
    [HttpGet]
    public IActionResult Register()
    {
        RegisterViewModel rv = new RegisterViewModel();
        return View(rv);
    }

   // POST: /Account/Register
   [HttpPost]
   [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Map the RegisterViewModel data to ApplicationUser
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Address = model.Address };

            if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
            {
                // Process and save the profile picture (optional)
                using (var memoryStream = new MemoryStream())
                {
                    await model.ProfilePicture.CopyToAsync(memoryStream);
                    user.ProfilePicture = memoryStream.ToArray(); // Store the profile picture as bytes
                }
            }
            else
            {
                user.ProfilePicture = GetDefaultProfilePictureBytes(); // Assign default picture bytes if no picture is uploaded
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    private byte[] GetDefaultProfilePictureBytes()
    {
        string defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/default.png");
        return System.IO.File.ReadAllBytes(defaultImagePath); // Load the default picture from file and return bytes
    }


    // POST: /Account/Logout

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Helper method to redirect to local URL
   
}
