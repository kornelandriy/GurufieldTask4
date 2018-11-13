using System;
using WebApp.DAL.Context;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repositories
{
        public class EfUnitOfWork : IUnitOfWork
        {
            private readonly MobileContext _mobileContext;
            private PhoneRepository _phoneRepository;

            public EfUnitOfWork(MobileContext mobileContext)
            {
                _mobileContext = mobileContext;
                _phoneRepository = new PhoneRepository(mobileContext);
            }

            public IRepository<Phone> Phones =>
                _phoneRepository ?? (_phoneRepository = new PhoneRepository(_mobileContext));

            public void Save()
            {
                _mobileContext.SaveChanges();
            }

            public void Dispose()
            {
                _mobileContext.Dispose();
                GC.SuppressFinalize(this);
            }
        }
}