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
    public class TypeDomageRepository : ITypeDomageRepository
    {
        private static DatabaseContext _databaseContext;
        public TypeDomageRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<TypeDomageModel> GetDomageList()
        {
            return _databaseContext.TypeDomage.Select(x => new TypeDomageModel()
            {
                Id = x.Id,
                Nom = x.Nom,
             
            }).ToList();
        }
    }
}
