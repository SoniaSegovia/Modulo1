using FastDeliveryApi.Repositories;

namespace FastDeliveryApi.Entity;


public class Customer : IAuditableEntity
{
  public int Id { get; set; }
  public string  Name { get; set; }

  public string PhoneNumber { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public bool Status { get; set; }
public DateTime CreatedOnUtc {get ; set ;}

public DateTime? ModifiedOnUtc {get ; set ;}

}
