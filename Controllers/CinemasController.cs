using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {

       

        private readonly AppDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public CinemasController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, AppDbContext context)
        {
            this.hostingEnvironment = hostingEnvironment;
            _context = context;
        }

       public async Task<IActionResult> Index()
        {
            var allcinema = await _context.Cinemas.ToListAsync();
            return View(allcinema);
        }
       
    }
}
