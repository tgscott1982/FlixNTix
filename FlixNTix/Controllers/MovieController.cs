using FlixNTix.Data;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public async Task<IActionResult> Filter(string searchString)
    {
        var allMovies = await _service.GetAllAsync(n => n.Theater);

        if (!string.IsNullOrEmpty(searchString))
        {
            var filteredResult = allMovies.Where(n => n.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
            n.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            return View("Index", filteredResult);
        }
        return View("NotFound");
    }

    //get - movies/details

    public async Task<IActionResult> Details(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);
        return View(movieDetails);
    }

    //get - movies/create

    public async Task<IActionResult> Create()
    {
        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        ViewBag.Theaters = new SelectList(movieDropdownsData.Theaters, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
        
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(NewMovieVM movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Theaters = new SelectList(movieDropdownsData.Theaters, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }
        await _service.AddNewMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    //get - movies/edit

    public async Task<IActionResult> Edit(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);
        if (movieDetails == null) return View("NotFound");

        var response = new NewMovieVM()
        {
            Id = movieDetails.Id,
            Name = movieDetails.Name,
            Description = movieDetails.Description,
            Price = movieDetails.Price,
            StartDate = movieDetails.StartDate,
            EndDate = movieDetails.EndDate,
            ImageURL = movieDetails.ImageURL,
            MovieCategory = movieDetails.MovieCategory,
            TheaterId = movieDetails.TheaterId,
            ProducerId = movieDetails.ProducerId,
            ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
        };

        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        ViewBag.Theaters = new SelectList(movieDropdownsData.Theaters, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieVM movie)
    {
        if (id != movie.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Theaters = new SelectList(movieDropdownsData.Theaters, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }
        await _service.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Privacy()
    {
        ViewData["Welcome"] = "Welcome To The Vault";
        ViewBag.Description = "This Is How We Do";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
