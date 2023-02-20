using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class LibshowController : Controller
    {
        private readonly LibraryContext _context;
        public DataBook databook = new DataBook();
        public LibshowController(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(DataBook databook)
        {
            var allbooks=await _context.Books.ToListAsync();
            var sortedBooks = allbooks.OrderBy(b => b.book_title.FirstOrDefault()).ToList();
            var bookLetters = sortedBooks.Select(b => b.book_title.FirstOrDefault()).Distinct().ToList();
            var link = sortedBooks.Select(b => b.cover).ToList();
            var total = sortedBooks.Count();
     

            databook.total = total;
            databook.bookdata=sortedBooks;
            databook.bookletter = bookLetters;
            databook.url = link;
            return View(databook);
        }
    }
}
