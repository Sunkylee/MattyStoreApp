using MattyStoreApp.DataAccess.Data;
using MattyStoreApp.DataAccess.Repository.IRepository;
using MattyStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattyStoreApp.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {

        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _db.Update(shoppingCart);

           // _db.SaveChanges();
        }
    }
}
