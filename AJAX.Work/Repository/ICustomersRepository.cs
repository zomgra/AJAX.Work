using AJAX.Work.Models;

namespace AJAX.Work.Repository
{
    public interface ICustomersRepository
    {
        List<Customer> GetAll();
        Customer GetCustomersById(int id);
        IEnumerable<string> GetAllName();
        Task DeleteById(int v);
    }
}
