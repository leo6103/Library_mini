using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;



namespace Library.Controllers
{   
    //public class Sess:Controller
    //{
    //    public static IHttpContextAccessor _context_session;
    //    public Sess(IHttpContextAccessor context_session)
    //    {
           
    //        _context_session = context_session;
    //    }
    //}
    public class LoginController : Controller
    {

        private readonly LibraryContext _context;
        public IHttpContextAccessor _context_session;
        //constructor
        public LoginController(LibraryContext context, IHttpContextAccessor context_session)
        {
            _context = context;
            _context_session = context_session;
        }
        
        //GET login
       
        public IActionResult Index()
        {
            //logic
            return View();
        }
        //POST login
        [HttpPost]
        public async Task<IActionResult> Index(string account, string password)
        {
            var match_accounts = await _context.User.Where(a => a.account == account).ToListAsync();
            var match_accounts_pass= await _context.User.Where(a => a.account == account&&a.password==password).ToListAsync();
            if (!match_accounts.Any())
            {

                _context_session.HttpContext.Session.SetString("error_account", "Account does not exist");
                return View();
            }
            else if (match_accounts.Any() && !match_accounts_pass.Any())
            {
                //data_user.error_password = "Password is not true";
                _context_session.HttpContext.Session.SetString("error_account", "Password is not true");
                return View();
            }
            else/*(match_accounts.Any() && !match_accounts_pass.Any())*/
            {
                //data_user.user_id = match_accounts[0].user_id;
                //Console.WriteLine(data_user.user_id);
                _context_session.HttpContext.Session.SetInt32("user_id", (int)match_accounts[0].user_id);
                _context_session.HttpContext.Session.SetString("acc_name", account);
                return RedirectToAction("Index", "Home");
            }
        }
        //Get Signup
        public IActionResult SignUp()
        {
            return View();
        }
        //Post Signup
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            //logic
            if(ModelState.IsValid)
            {
                user.date_create = DateTime.Now;
                user.last_login= DateTime.Now;
                _context.Add(user);
                await _context.SaveChangesAsync();
               
                return RedirectToAction("Index","Home", user.user_id);
            }
            return View();
        }
        //POST signup
        //[HttpPost]
        //[ValidateAntiForgeryToken]


    }
}
