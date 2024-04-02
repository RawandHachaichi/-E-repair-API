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
    public class CauseRepository: ICauseRepository
    {
        private static DatabaseContext _databaseContext;
        public CauseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<CauseModel> GetCause()
        {
            return _databaseContext.Causes.Select(x => new CauseModel()
            {
                Id = x.Id,
                Nom = x.Nom,
                
            }).ToList();
        }
    }
}
