using WebApp.DAL.Entities;

namespace WebApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Phone> Phones { get;}
        void Save();
    }
}