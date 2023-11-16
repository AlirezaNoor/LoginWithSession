using System.Diagnostics;
using Loginwithsessionexp.context;
using Microsoft.AspNetCore.Mvc;
using Loginwithsessionexp.Models;
using Loginwithsessionexp.Models.entity;

namespace Loginwithsessionexp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _myContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(ILogger<HomeController> logger, MyContext myContext, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _myContext = myContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        var usercheker = _myContext.user.Where(x => x.usename == user.usename && x.password == user.password);
        if (usercheker.Count() > 0)
        {
            _httpContextAccessor.HttpContext.Session.SetString("username", user.usename);
           
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "نام کاربری یا رمز عبور نادرست است.";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}