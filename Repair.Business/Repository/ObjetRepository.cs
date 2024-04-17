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
    public class ObjetRepository : IObjetRepository
    {
        private static DatabaseContext _databaseContext;
        public ObjetRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ItemModel> GetObjet()
        {
            return _databaseContext.Objets.Select(x => new ItemModel()
            {
                Id = x.Id,
                Nom = x.Nom,
             
            }).ToList();
        }
    }
}
