using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Library.Controllers
{
    public class LibshowController : Controller
    {
        private readonly LibraryContext _context;
        //public DataBook databook = new DataBook();
        public IHttpContextAccessor _context_session;
        public LibshowController(LibraryContext context,IHttpContextAccessor context_session)
        {
            _context = context;
            _context_session = context_session;
        }
        public async Task<IActionResult> Index()
        {
            var allbooks=await _context.Books.ToListAsync();
            var sortedBooks = allbooks.OrderBy(b => b.book_title.FirstOrDefault()).ToList();
            var bookLetters = sortedBooks.Select(b => b.book_title.FirstOrDefault()).Distinct().ToList();
            var link = sortedBooks.Select(b => b.cover).ToList();
            var total = sortedBooks.Count();
     

           
            string session_book=JsonConvert.SerializeObject(sortedBooks);
            Console.WriteLine(session_book);
            _context_session.HttpContext.Session.SetString("book", session_book);
            _context_session.HttpContext.Session.SetInt32("total", total);
            return View();
        }
    }
}
