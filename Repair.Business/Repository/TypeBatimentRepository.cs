using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Repository
{
    public class TypeBatimentRepository : ITypeBatimentRepository
    {
        private static DatabaseContext _databaseContext;
        public TypeBatimentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ItemModel> GetBatimentList()
        {
            return _databaseContext.TypeBatiment.Select(x => new ItemModel()
            {
                Id = x.Id,
                Nom = x.Nom,
                
            }).ToList();
        }
    }
}
