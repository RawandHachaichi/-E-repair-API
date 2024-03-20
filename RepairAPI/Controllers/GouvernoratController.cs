using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GouvernoratController : ControllerBase
    {
        private static IGouvernoratRepository _IGouvernoratRepository;
        public GouvernoratController(IGouvernoratRepository gouvernoratRepository) {
            _IGouvernoratRepository = gouvernoratRepository;
        }
        [HttpGet]
        public List<GouvernoratModel> GetAllGouv()
        {
            return _IGouvernoratRepository.GetGouvernoratList();

        }
    }
}
