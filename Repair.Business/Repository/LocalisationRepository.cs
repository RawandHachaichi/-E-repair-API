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
    public class LocalisationRepository : ILocalisationRepository
    {
        private static DatabaseContext _databaseContext;
        public LocalisationRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<LocalisationModel> GetLocalisation()
        {
            return _databaseContext.Localisations.Select(x => new LocalisationModel()
            {
                Id = x.Id,
                Nom = x.Nom,
            }).ToList();
        }
    }
}
