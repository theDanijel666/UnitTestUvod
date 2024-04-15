using MVC_employee.Models;

namespace MVC_employee.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Add(Employee employee);
    }
}
