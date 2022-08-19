using FlixNTix.Data;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FlixNTix.Controllers;
public class MovieController : Controller
{
    private readonly IMovieService _service;
    public MovieController(IMovieService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allMovies = await _service.GetAllAsync(n => n.Theater);
        return View(allMovies);
    }

    //get - movies/create

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        ViewData["Wecome"] = "Welcome To The Vault";
        ViewBag.Description = "This Is How We Do";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //get - movies/details

    public async Task<IActionResult> Details(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);
        return View(movieDetails);
    }
}
