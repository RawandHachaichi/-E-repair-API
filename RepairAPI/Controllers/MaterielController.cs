using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterielController : ControllerBase
    {
        private static IMaterielRepository _IMaterielRepository;
        public MaterielController(IMaterielRepository MaterielRepository)
        {
            _IMaterielRepository = MaterielRepository;
        }

        [HttpGet]
        public List<MaterielModel> GetMateriellist()
        {
            return _IMaterielRepository.GetMateriel();
        }


    }
}
