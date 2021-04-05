using Harissa.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Harissa.Intranet.Controllers.Abstract
{
    abstract public class BaseClassController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly HarissaContext _context;

        public BaseClassController(ILogger<HomeController> logger, HarissaContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}