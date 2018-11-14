using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.DAL.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _dbUnit;

        public SearchController(IUnitOfWork dbUnit) => _dbUnit = dbUnit;

        [HttpGet("[action]")]
        public IEnumerable<string> Find(string str)
        {
            return _dbUnit.Phones
                .Find(item => item.Name.Contains(str))
                .Select(phone => phone.Name)
                .ToList();
        }
    }
}