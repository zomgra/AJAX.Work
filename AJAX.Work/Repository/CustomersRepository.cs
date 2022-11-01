using AJAX.Work.Models;

namespace AJAX.Work.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> _customers;
        public CustomersRepository()
        {
            _customers = new List<Customer>() 
            {
                new Customer()
                {
                    Id = 0,
                    Name = "Eugine", Age = 23, SecondName = "Wood"
                },
                new Customer()
                {
                    Id = 1,
                    Name = "Mike", Age = 31, SecondName = "Noisky",
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Lili", Age = 17, SecondName = "Adam",
                }, 
                new Customer()
                {
                    Id = 3,
                    Name = "Angela", Age = 60, SecondName = "Wood"
                }, 
                new Customer()
                {
                    Id = 4,
                    Name = "Marta", Age = 18, SecondName = "Kohan"
                },
                new Customer()
                {
                    Id = 5,
                    Name = "Noize", Age = 61, SecondName = "Wood"
                }
            };
        }

        public async Task DeleteById(int v)
        {
            var cus = GetCustomersById(v);
            if (cus != null)
            {
                await Task.Delay(2000); //For wait test 
                _customers.Remove(cus);
            }
        }

        //TODO: Make null exeption
        public List<Customer> GetAll() => _customers;

        public IEnumerable<string> GetAllName()
        {
            return _customers.Select(o => o.Name);
        }

        //TODO: Make null exeption
        public Customer GetCustomersById(int id) => _customers.FirstOrDefault(x => x.Id == id);
    }
}