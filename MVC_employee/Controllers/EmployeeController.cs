using Microsoft.AspNetCore.Mvc;
using MVC_employee.Interfaces;
using MVC_employee.Models;

namespace MVC_employee.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(employee);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
