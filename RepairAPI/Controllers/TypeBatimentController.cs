using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeBatimentController : ControllerBase
    {
        private static ITypeBatimentRepository _ITypeBatimentRepository;
        public TypeBatimentController(ITypeBatimentRepository TypeBatimentRepository)
        {
            _ITypeBatimentRepository = TypeBatimentRepository;
        }
        [HttpGet]
        public List<TypeBatimentModel> GetBatimentList()
        {
            return _ITypeBatimentRepository.GetBatimentList();
        }

    }
}
