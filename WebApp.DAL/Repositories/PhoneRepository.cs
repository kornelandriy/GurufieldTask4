using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Context;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private readonly MobileContext _mobileContext;
 
        public PhoneRepository(MobileContext context) => _mobileContext = context;
 
        public IEnumerable<Phone> GetAll() => _mobileContext.Phones;
 
        public Phone Get(int id) => _mobileContext.Phones.Find(id);
 
        public void Create(Phone book) => _mobileContext.Phones.Add(book);
 
        public void Update(Phone book) => _mobileContext.Entry(book).State = EntityState.Modified;
 
        public IEnumerable<Phone> Find(Func<Phone, Boolean> predicate) => _mobileContext.Phones.Where(predicate).ToList();
 
        public void Delete(int id)
        {
            Phone book = _mobileContext.Phones.Find(id);
            if (book != null)
                _mobileContext.Phones.Remove(book);
        }
    }
}