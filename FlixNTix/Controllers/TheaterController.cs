using FlixNTix.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Controllers;
public class TheaterController : Controller
{
    private readonly ApplicationDbContext _context;

    public TheaterController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var allTheaters = await _context.Theaters.ToListAsync();
        return View(allTheaters);
    }
}
