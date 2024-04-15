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
    public class TypeRendezVousRepository : ITypeRendezVousRepository
    {
        private static DatabaseContext _databaseContext;
        public TypeRendezVousRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<TypeRendezVousModel> GetType()
        {
            return _databaseContext.TypeRendezVous.Select(x => new TypeRendezVousModel()
            {
                Id = x.Id,
                Nom = x.Nom
            }).ToList();
        }
    }
}
