using MattyStoreApp.DataAccess.Data;
using MattyStoreApp.DataAccess.Repository.IRepository;
using MattyStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattyStoreApp.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType CoverType)
        {
            var objFromDb = _db.CoverTypes.FirstOrDefault(x => x.Id == CoverType.Id);
            objFromDb.Name = CoverType.Name;       
        }
    }
}
