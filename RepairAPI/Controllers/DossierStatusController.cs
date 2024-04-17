using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DossierStatusController : ControllerBase
    {
        private static IDossierStatusRepository _IDossierStatusRepository;

        public DossierStatusController(IDossierStatusRepository DossierStatusRepository)
        {
            _IDossierStatusRepository = DossierStatusRepository;
        }
        [HttpGet]
        public List<DossierStatusModel> GetStatus() 
        {
            return _IDossierStatusRepository.GetStatus();
        }
    }
}
