using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceController : ControllerBase
    {
        private static ICompetenceRepository _ICompetenceRepository;
        public CompetenceController( ICompetenceRepository ICompetenceRepository)
        {
            _ICompetenceRepository = ICompetenceRepository;
        }

     
        [HttpGet]
        public List<CompetenceModel> GetAllComp()
        {
            return _ICompetenceRepository.GetCompetenceList();

        }

    }
}
