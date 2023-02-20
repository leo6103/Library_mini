using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class LoginController : Controller
    {

        private readonly LibraryContext _context;
        public DataUser data_user=new DataUser();
        //constructor
        public LoginController(LibraryContext context)
        {
            _context = context;
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
                data_user.error_account = "Account does not exist";
                return View(data_user);
            }
            else if (match_accounts.Any() && !match_accounts_pass.Any())
            {
                data_user.error_password = "Password is not true";
                return View(data_user);
            }
            else/*(match_accounts.Any() && !match_accounts_pass.Any())*/
            {
                data_user.user_id = match_accounts[0].user_id;
                Console.WriteLine(data_user.user_id);
                return RedirectToAction("Index", "Home", data_user);
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
                data_user.user_id = user.user_id;
                return RedirectToAction("Index","Home",data_user);
            }
            return View();
        }
        //POST signup
        //[HttpPost]
        //[ValidateAntiForgeryToken]


    }
}
