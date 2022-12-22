using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderProcess.Models;
using System.Diagnostics;
using System.Linq;

namespace OrderProcess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrderProcessDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, OrderProcessDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var processOrderList = _dbContext.ProcessOrder.ToList();
            return View(processOrderList);
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
