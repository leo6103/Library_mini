using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Library.Models;

namespace Library.Controllers
{
    public class AddbookController:Controller
    {
        private readonly LibraryContext _context;
        //public DataBook databook = new DataBook();
        public IHttpContextAccessor _context_session;
        public AddbookController(LibraryContext context, IHttpContextAccessor context_session)
        {
            _context = context;
            _context_session = context_session;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Book book, IFormFile image)
        {
            
            book.cover = "img/"+image.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", image.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","libshow");
        }
    }
}
