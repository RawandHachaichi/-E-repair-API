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
    public class GouvernoratRepository : IGouvernoratRepository
    {
        private static DatabaseContext _databaseContext;

        public GouvernoratRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<GouvernoratModel> GetGouvernoratList()
        {
            return _databaseContext.Gouvernorats.Select(x => new GouvernoratModel()
            {
                Id = x.Id,
                Nom = x.Nom,
                Code = x.Code,
            }).ToList();
        }
    }
}
