using System;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Phone> Phones { get;}
        void Save();
    }
}