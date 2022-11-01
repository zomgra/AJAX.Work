using AJAX.Work.Models;
using AJAX.Work.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AJAX.Work.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomersRepository _customersRepository;

        public HomeController(ILogger<HomeController> logger, ICustomersRepository customersRepository)
        {
            _logger = logger;
            this._customersRepository = customersRepository;
        }

        public IActionResult Index()
        {
            return View();
            
            //return PartialView("_CustomersInfo", new Customer { Age = 11, Name = "Vasya", SecondName = "Pupkin"});
        }
        public IActionResult Find()
        {
            return View();
        }
        public IActionResult DeleteCustomer()
        {
            return View(_customersRepository.GetAll());
        }
        public IActionResult Customers()
        {
            var tuple = new Tuple<List<Customer>, Customer>(_customersRepository.GetAll(), _customersRepository.GetCustomersById(0));
            return View(tuple);
        }
        public IActionResult OnSelectCustomer(string id)
        {
            var res = _customersRepository.GetCustomersById(int.Parse(id));
            return PartialView("_CustomersInfo", res);
        }
        public IActionResult OnFindCustomers(string findText)
        {
            var i = _customersRepository.GetAll().Where(o => o.SecondName.Contains($"{findText}"));
            return PartialView("_MoreCustomers", i);
        }
        public async Task<IActionResult> OnDeleteCustomer(string id)
        {
            await _customersRepository.DeleteById(int.Parse(id));
            var all = _customersRepository.GetAll();
            
            return PartialView("_InteractCustomers", all);
        }
    }
}