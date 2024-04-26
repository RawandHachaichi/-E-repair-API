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
    public class TypeDocumentRepository : ITypeDocumentRepository
    {
        private static DatabaseContext _databaseContext;
        public TypeDocumentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ItemModel> GetTypeDocument()
        {
            return _databaseContext.TypeDocument.Select(x => new ItemModel()
            {
                Id = x.Id,
                Nom = x.Nom,
                CreePar = x.CreePar,
                DateCreation = x.DateCreation,

            }).ToList();
        }
    }
}
