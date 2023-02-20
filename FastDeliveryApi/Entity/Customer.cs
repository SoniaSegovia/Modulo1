using FastDeliveryApi.Repositories;

namespace FastDeliveryApi.Entity;


public class Customer : IAuditableEntity
{
  public Customer(string name, string phoneNumber, string email, string address)
  {
     Name = name;
     PhoneNumber = phoneNumber;
     Email = email;
     Address = address;
     Status = true ;       
  }
  public int Id { get; set; }
  public string  Name { get; set; }

  public string PhoneNumber { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public bool Status { get; set; }
public DateTime CreatedOnUtc {get ; set ;}

public DateTime? ModifiedOnUtc {get ; set ;}

}
