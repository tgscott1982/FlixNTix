using FlixNTix.Data;
using FlixNTix.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Controllers;
public class ActorController : Controller
{
    private readonly IActorService _service;

    public ActorController(IActorService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAll();
        return View(allActors);
    }

    //Get request: actors/create
    public async Task<IActionResult> Create()
    {
        return View();
    }
}
