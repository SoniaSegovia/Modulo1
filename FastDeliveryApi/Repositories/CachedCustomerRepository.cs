using FastDeliveryApi.Entity;
using FastDeliveryApi.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FastDeliveryApi.Repositories;


public class CachedCustomerRepository : ICustomerRepository
{
    private readonly ICustomerRepository  _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedCustomerRepository(ICustomerRepository decorated, IMemoryCache memoryCache)
      {
        _decorated = decorated;
        _memoryCache = memoryCache;
      }
    public void Add(Customer customer){
      _memoryCache.Remove("llave");

      _decorated.Add(customer);
    }

     public async Task<IReadOnlyCollection<Customer>> GetAll()
     {
      string key ="GetAllCustomers";

      return _memoryCache.GetOrCreateAsync(key,
        entry   => {
         return await _decorated.GetAll();
      }
      );
     }
    public Task<Customer?> GetCustomerById(int id, CancellationToken cancellationToken = default)
     {
        string key = $"customer-{id}";

        return _memoryCache.GetOrCreateAsync(

         key, 
         entry => {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
            
            return _decorated.GetCustomerById(id, cancellationToken);
         });
        }

      public void RemovedCustomer(int id, Object id, CachedCustomerRepository id){
         Removed = true;
      reason = id;
}
    public void Update(Customer customer) =>
      _decorated.Update(customer); 
}

