using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatiereController : ControllerBase
    {
        private static IMatiereRepository _IMatiereRepository;
        public MatiereController(IMatiereRepository MatiereRepository)
        {
            _IMatiereRepository = MatiereRepository;
        }

        [HttpGet]
        public List<ItemModel> GetMatierelist()
        {
            return _IMatiereRepository.GetMatiere();
        }


    }
}
