﻿using FlixNTix.Data.Cart;
using FlixNTix.Data.Interfaces;
using FlixNTix.Data.Repositories;
using FlixNTix.Data.Static;
using FlixNTix.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlixNTix.Controllers;

[Authorize]
public class OrderController : Controller
{
    private readonly IMovieService _movieService;
    private readonly ShoppingCart _shoppingCart;
    private readonly IOrderService _orderService;
    public OrderController(IMovieService movieService, ShoppingCart shoppingCart, IOrderService orderService)
    {
        _movieService = movieService;
        _shoppingCart = shoppingCart;
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userRole =User.FindFirstValue(ClaimTypes.Role);
        var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
        return View(orders);
    }
    public IActionResult ShoppingCart()
    {
        var items = _shoppingCart.GetShoppingCartItems();

        _shoppingCart.ShoppingCartItems = items;
        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetshoppingCartTotal()
        };

        return View(response);
    }

    public async Task<IActionResult> AddItemToShoppingCart(int id)
    {
        var item = await _movieService.GetMovieByIdAsync(id);
        if (item != null)
        {
            _shoppingCart.AddItemToCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
    {
        var item = await _movieService.GetMovieByIdAsync(id);

        if (item != null)
        {
            _shoppingCart.RemoveItemFromCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> CompleteOrder()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

        await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
        await _shoppingCart.ClearShoppingCartAsync();

        return View("OrderCompleted");
    }
}
