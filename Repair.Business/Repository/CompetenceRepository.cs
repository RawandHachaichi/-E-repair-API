using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;

namespace Repair.Business.Repository
{
    public class CompetenceRepository : ICompetenceRepository
    {
        private static DatabaseContext _databaseContext;
        public CompetenceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

            public List<CompetenceModel> GetCompetenceList()
            {
                return _databaseContext.Competences.Select(x => new CompetenceModel()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    Code = x.Code,
                    CreePar = x.CreePar,
                    DateCreation = x.DateCreation,

                }).ToList();

            }

        }


    }


