using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet("{orderId}")]
    public IActionResult GetOrderById(int orderId)
    {
        var response = new OrderResponse(Guid.NewGuid(), "John Doe", "Laptop", 1, 1000, HttpContext.TraceIdentifier);
        return Ok(response);
    }


    [HttpPost("create")]
    public IActionResult CreateOrder([FromBody] OrderRequest request)
    {
        var response = new OrderResponse(Guid.NewGuid(), request.CustomerName, request.ProductName, request.Quantity,
            request.Price, HttpContext.TraceIdentifier);
        return Ok(response);
    }
}

public record struct OrderRequest
{
    public string CustomerName { get; init; }
    public string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}

public record struct OrderResponse(Guid Id, string CustomerName, string ProductName, int Quantity, decimal Price,
    string RequestId);