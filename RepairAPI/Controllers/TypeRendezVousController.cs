using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeRendezVousController : ControllerBase
    {
        private static ITypeRendezVousRepository _ITypeRendezVousRepository;
        public TypeRendezVousController(ITypeRendezVousRepository TypeRendezVousRepository)
        {
            _ITypeRendezVousRepository = TypeRendezVousRepository;
        }

        [HttpGet]
        public List<ItemModel> GetType()
        {
            return _ITypeRendezVousRepository.GetType();
        }

    }
}
