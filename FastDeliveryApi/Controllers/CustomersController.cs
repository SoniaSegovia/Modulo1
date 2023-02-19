using Microsoft.AspNetCore.Mvc;
using FastDeliveryApi.Data;
using FastDeliveryApi.Entity;
using FastDeliveryApi.Repositories.Interfaces;

namespace FastDeliveryApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersControllers : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomersControllers(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
public ActionResult<IEnumerable<Customer>> Get()
{
    var customers = _customerRepository.GetAll();
    return Ok(customers);
 }
}
 [HttpGet("Customers/SearchId")]
    public ActionResult<Customer> Get(int id)
    {
        Customer var  = _context. customers. Find(id);
        if (customers == null)
        {
            return NotFound();
        }
        "Cliente que regresan";
    }

    [httpPost("Customers/Guardar")]
    public ActionResult Create(Customer customers )
    {
        _context. customers. Add(customers);
        _context. SaveChanges();
        return RedirectToAction("Index", "Customers");
    }
 