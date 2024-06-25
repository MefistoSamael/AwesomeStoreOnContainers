﻿namespace Ordering.Application.Common.Models;

public class OrderDTO
{
    required public string Id { get; set; }

    required public string BuyerEmail { get; set; }

    required public List<OrderItemDTO>? OrderItems { get; set; }

    required public string State { get; set; }
}