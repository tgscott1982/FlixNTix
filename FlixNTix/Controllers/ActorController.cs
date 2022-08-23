using FlixNTix.Data;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Controllers;

[Authorize]
public class ActorController : Controller
{

    private readonly IActorService _service;

    public ActorController(IActorService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAllAsync();
        return View(allActors);
    }

    //Get request: actors/create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }
        await _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    //get: actor/details
    [AllowAnonymous]

    public async Task<IActionResult> Details(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);

    }

    //Get request: actors/edit
    public async Task<IActionResult> Edit(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }
        await _service.UpdateAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }

    //Get request: actors/delete
    public async Task<IActionResult> Delete(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
