using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauseController : ControllerBase
    {
        private static ICauseRepository _ICauseRepository;

        public CauseController(ICauseRepository CauseRepository)
        {
            _ICauseRepository = CauseRepository;
        }
        [HttpGet]
        public List<ItemModel> GetCauseList()
        {
            return _ICauseRepository.GetCause();
        }
    }
}
