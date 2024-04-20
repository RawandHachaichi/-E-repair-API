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
    public class DossierStatusRepository : IDossierStatusRepository
    {
        private static DatabaseContext _databaseContext;
        public DossierStatusRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
         public List<DossierStatusModel> GetStatus()
        {
            
                return _databaseContext.DossierStatus.Select(x => new DossierStatusModel()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    Code=x.code
                }).ToList();

            
        }
    }
}
