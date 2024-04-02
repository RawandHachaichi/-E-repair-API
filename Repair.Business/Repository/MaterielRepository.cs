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
    public class MaterielRepository : IMaterielRepository
    {
        private static DatabaseContext _databaseContext;
        public MaterielRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<MaterielModel> GetMateriel()
        {
            return _databaseContext.Materiels.Select(x => new MaterielModel()
            {
                Id = x.Id,
                Nom = x.Nom,
            }).ToList();
        }
    }
}
