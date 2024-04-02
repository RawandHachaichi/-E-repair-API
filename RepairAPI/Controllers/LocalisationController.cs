using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalisationController : ControllerBase
    {
        private static ILocalisationRepository _ILocalisationRepository;
        public LocalisationController(ILocalisationRepository LocalisationRepository)
        {
            _ILocalisationRepository = LocalisationRepository;
        }

        [HttpGet]
        public List<LocalisationModel> GetLocalisationList()
        {
            return _ILocalisationRepository.GetLocalisation();
        }

    }
}
