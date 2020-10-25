using MattyStoreApp.DataAccess.Data;
using MattyStoreApp.DataAccess.Repository.IRepository;
using MattyStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattyStoreApp.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {

        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.Update(orderHeader);

           // _db.SaveChanges();
        }
    }
}
