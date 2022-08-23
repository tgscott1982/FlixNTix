using FlixNTix.Data;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Controllers;
[Authorize]
public class TheaterController : Controller
{
    private readonly ITheaterService _service;

    public TheaterController(ITheaterService service)
    {
        _service = service;
    }

    //index 
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allTheaters = await _service.GetAllAsync();
        return View(allTheaters);
    }

    //get - theater/create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Theater theater)
    {
        if (!ModelState.IsValid) return View(theater);

        await _service.AddAsync(theater);
        return RedirectToAction(nameof(Index));
    }

    //get - theater/details
    [AllowAnonymous]

    public async Task<IActionResult> Details(int id)
    {
        var theaterDetails = await _service.GetByIdAsync(id);
        if (theaterDetails == null) return View("NotFound");
        return View(theaterDetails);
    }

    //get - theater/edit

    public async Task<IActionResult> Edit(int id)
    {
        var theaterDetails = await _service.GetByIdAsync(id);
        if (theaterDetails == null) return View("NotFound");
        return View(theaterDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Theater theater)
    {
        if (!ModelState.IsValid) return View(theater);

        if (id == theater.Id)
        {
            _service.UpdateAsync(id, theater);
            return RedirectToAction(nameof(Index));
        }
        return View(theater);
    }

    //get - producer/delete

    public async Task<IActionResult> Delete(int id)
    {
        var theaterDetails = await _service.GetByIdAsync(id);
        if (theaterDetails == null) return View("NotFound");
        return View(theaterDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        var theaterDetails = await _service.GetByIdAsync(id);
        if (theaterDetails == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));

    }
}
