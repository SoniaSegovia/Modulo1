using Microsoft.AspNetCore.Mvc;
using FastDeliveryApi.Data;
using FastDeliveryApi.Entity;

namespace FastDeliveryApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersControllers : ControllerBase
{
    private readonly FastDeliveryDbContext _context;

    public CustomersControllers(FastDeliveryDbContext context) => _context = context;

    [HttpGet]
public ActionResult<IEnumerable<Customer>> Get()
{
    var customers = _context.Customers.ToList();
    return Ok(customers);
 }
}