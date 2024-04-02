using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetController : ControllerBase
    {
        private static IObjetRepository _IObjetRepository;
        public ObjetController(IObjetRepository ObjetRepository)
        {
            _IObjetRepository = ObjetRepository;
        }
        [HttpGet]
        public List<ObjetModel> GetObjetList()
        {
            return _IObjetRepository.GetObjet();
        }

    }
}
