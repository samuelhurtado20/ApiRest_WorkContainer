using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class WorkContainer : IWorkContainer
    {
        private readonly ApplicationDbContext _db;
        public ICustomerRepository Customer { get; private set; }

        public WorkContainer(ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
