using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.DAL.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork dbUnit) => _unitOfWork = dbUnit;

        [HttpGet("[action]")]
        public IEnumerable<string> Find(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return null;
            return _unitOfWork.Phones
                .Find(item => item.Name
                    .ToUpper()
                    .Contains(searchString.ToUpper()))
                .Select(phone => phone.Name)
                .ToList();
        }
        
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}