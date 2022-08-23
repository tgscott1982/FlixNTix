using FlixNTix.Data;
using FlixNTix.Data.Interfaces;
using FlixNTix.Data.Static;
using FlixNTix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class ProducerController : Controller
{
    private readonly IProducerService _service;

    public ProducerController(IProducerService service)
    {
        _service = service;
    }

    //index
    [AllowAnonymous]

    public async Task<IActionResult> Index()
    {
        var allProducers = await _service.GetAllAsync();
        return View(allProducers);
    }

    //get - producer/details
    [AllowAnonymous]

    public async Task<IActionResult> Details(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null) return View("NotFound");
        return View(producerDetails);
    }

    //get - producer/create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid) return View(producer);

        _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    //get - producer/edit

    public async Task<IActionResult> Edit(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null) return View("NotFound");
        return View(producerDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid) return View(producer);

        if (id == producer.Id)
        {
            _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
        return View(producer);
    }

    //get - producer/delete

    public async Task<IActionResult> Delete(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null) return View("NotFound");
        return View(producerDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));

    }
}
