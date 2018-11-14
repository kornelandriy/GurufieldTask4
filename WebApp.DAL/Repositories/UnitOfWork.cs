using System;
using WebApp.DAL.Context;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MobileContext _mobileContext;

        private bool _disposed;
        private PhoneRepository _phoneRepository;

        public UnitOfWork(MobileContext mobileContext)
        {
            _mobileContext = mobileContext;
            _phoneRepository = new PhoneRepository(mobileContext);
        }

        public IRepository<Phone> Phones =>
            _phoneRepository ?? (_phoneRepository = new PhoneRepository(_mobileContext));

        public void Save() => _mobileContext.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _mobileContext.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}