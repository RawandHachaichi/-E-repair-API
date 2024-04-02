using Repair.Business.Models;
using System;



namespace Repair.Business.Interfaces
{
    public interface IDelegationRepository
    {
         public List<DelegationModel> GetDelegationByGouvId(Guid? id);
      
    }
}
