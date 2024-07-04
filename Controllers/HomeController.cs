using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger , SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses); 

            var total= allExpenses.Sum(x=>x.Value);
            ViewBag.Expenses=total;

        }
        public IActionResult CreateEditExpense(int? id)
        {
            
            if (id != null)
            {
                var expenseindb = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expenseindb);
            }

            return View();

        }
        public IActionResult DeleteExpense(int id)
        {
            var expenseindb=_context.Expenses.SingleOrDefault(x=> x.Id==id);
            _context.Expenses.Remove(expenseindb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");

        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {

            if(model.id==0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
           
            _context.SaveChanges();
            return RedirectToAction("Expenses");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
