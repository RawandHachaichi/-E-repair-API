using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private static ICategorieRepository _ICategorieRepository;

        public CategorieController(ICategorieRepository CategorieRepository)
        {
            _ICategorieRepository = CategorieRepository;
        }
        [HttpGet]
        public List<CategorieModel> GetCategoryList()
        {
            return _ICategorieRepository.GetCategorie();

        }
    }
    
}
