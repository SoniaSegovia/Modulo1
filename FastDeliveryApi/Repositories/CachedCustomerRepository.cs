using FastDeliveryApi.Entity;
using FastDeliveryApi.Repositories.Interfaces;

namespace FastDeliveryApi.Repositories;


public class CachedCustomerRepository : ICustomerRepository
{

    public void Add(Customer customer)
    {
        throw new NotImplementedException();
    }
     public Task<IReadOnlyCollection<Customer>> GetAll()
     {
        throw new NotImplementedException();

     }
    public Task<Customer?> GetCustomerById(int id, CancellationToken cancellationToken = default)
     {
        throw new NotImplementedException();

     }

     public void Update(Customer customer)
     {
        throw new NotImplementedException();

     }
}

