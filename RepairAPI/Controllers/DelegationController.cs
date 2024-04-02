using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegationController : ControllerBase
    {

        private static IDelegationRepository _IDelegationtRepository;

        public DelegationController(IDelegationRepository DelegationtRepository)
        {
            _IDelegationtRepository = DelegationtRepository;
        }


        [HttpGet]
        [Route("/Delegation/{id}")]
        public List<DelegationModel> GetDelegations(Guid?id)
        {
            return _IDelegationtRepository.GetDelegationByGouvId(id);

        }
    }
}
