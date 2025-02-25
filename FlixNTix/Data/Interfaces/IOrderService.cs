﻿using FlixNTix.Models;

namespace FlixNTix.Data.Interfaces;

public interface IOrderService
{
    Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
    Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);

}