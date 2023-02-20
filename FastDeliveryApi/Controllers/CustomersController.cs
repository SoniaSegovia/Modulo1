using Microsoft.AspNetCore.Mvc;

using FastDeliveryApi.Data;
using FastDeliveryApi.Entity;
using FastDeliveryApi.Repositories.Interfaces;
using FastDeliveryApi.Models;

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
 public async Task<ActionResult<IEnumerable<Customer>>> Get()
{
    var customers = await _customerRepository.GetAll();
    return Ok(customers);
 }

 [HttpPost]
 public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
     var customer = new Customer(
        request.Name,
        request.PhoneNumber,
        request.Email,
        request.Address
     );

     _customerRepository.Add(customer);

     await _unitOfWork.SaveChangesAsync();

     return CreatedAction(
        nameof(GetCustomerById), 
        new { id = customer.Id},
         customer);
    }  
    
 [HttpPut("{id:int}")]
public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
  {   
      var customer = await _customerRepository.GetCustomerById(id);
      if (customer is null )
     {
         return NotFound($"Customer Not Found with the Id {id}");
     }
     _customerRepository.Update(customer);

     await _unitOfWork.SaveChangesAsync();

     return NoContent();
    }

    [HttpGet("{id:int}")]
public async Task<IActionResult> GetCustomerById(int id, CancellationToken cancellationToken)

 {
    var customer = await _customerRepository.GetCustomerById(id);
    if (customer is null )
    {
        return NotFound($"Customer Not Found with the Id {id}");

    }
    return OK(customer);
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
 