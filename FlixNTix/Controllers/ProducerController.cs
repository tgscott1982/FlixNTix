using FlixNTix.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Controllers;
public class ProducerController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProducerController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var allProducers = await _context.Producers.ToListAsync();
        return View(allProducers);
    }
}
