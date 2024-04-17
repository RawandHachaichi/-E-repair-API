using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Repository
{
    public class CategorieRepository : ICategorieRepository
    {
        private static DatabaseContext _databaseContext;
        public CategorieRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<ItemModel> GetCategorie()
        {
            return _databaseContext.Categories.Select(x => new ItemModel()
            {
                Id = x.Id,
                Nom = x.Nom    
            }).ToList();

        }
    }
}
