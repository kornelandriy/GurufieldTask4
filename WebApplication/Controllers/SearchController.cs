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
        public IEnumerable<string> Find(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return null;
            return _dbUnit.Phones
                .Find(item => item.Name
                    .ToUpper()
                    .Contains(searchString.ToUpper()))
                .Select(phone => phone.Name)
                .ToList();
        }
    }
}