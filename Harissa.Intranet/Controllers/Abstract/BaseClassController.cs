using Harissa.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace Harissa.Intranet.Controllers.Abstract
{
    [Authorize]
    abstract public class BaseClassController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly HarissaContext _context;

        
        public BaseClassController(ILogger<HomeController> logger, HarissaContext context)
        {
            _logger = logger;
            _context = context;
        }


        //public void CollectionAdd()
        //{
        //    string typ = "bio";
        //    var cos = _context.Set<DbSet>(typ).FirstOrDefaultAsync().Result.
        //}

    }

}