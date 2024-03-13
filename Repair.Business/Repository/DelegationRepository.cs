using Repair.Business.Models;
using Repair.Business.Interfaces;
using Repair.Database;

namespace Repair.Business.Repository
{
    public class DelegationRepository : IDelegationRepository
    {
        private static  DatabaseContext _databaseContext;
        public DelegationRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }
        public List<DelegationModel> GetDelegationByGouvId(Guid? gouvId)
        {
            if (gouvId == null)
            {
                return _databaseContext.Delegations.Select(x => new DelegationModel()
                {

                    Id = x.Id,
                    Nom = x.Nom,
                    Code = x.Code,
                }).ToList();
            }
            else
            {

                return _databaseContext.Delegations.Where(x => x.GouvernoratId == gouvId).Select(x => new DelegationModel()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    Code = x.Code,
                }).ToList();
            }


        }

    }
}
