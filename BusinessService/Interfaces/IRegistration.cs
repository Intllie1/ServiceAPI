using RegistrationAPI.objects;
using RegistrationAPI.objects.Proxies;

namespace RegistrationAPI.BusinessService.Interfaces
{
    public interface IRegistration<TEntity>
    {
  
        IEnumerable<TEntity> GetAll();
         TEntity Get(int id);
        ResponseEntity AddRegistration(TEntity entity);
        ResponseEntity DeleteRegistration(TEntity dbEntity, TEntity entity);
        ResponseEntity UpdateRegistration(TEntity entity);
    }
}
