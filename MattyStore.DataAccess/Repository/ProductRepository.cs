using MattyStoreApp.DataAccess.Data;
using MattyStoreApp.DataAccess.Repository.IRepository;
using MattyStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattyStoreApp.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(x => x.Id == product.Id);

            if (objFromDb !=null)
            {
                if (product.ImageUrl != null) {

                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.ISBN = product.ISBN;
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.CoverTypeId = product.CoverTypeId;
                objFromDb.Author = product.Author;
            }

           // _db.SaveChanges();
        }
    }
}
