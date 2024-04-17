using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDomageController : ControllerBase
    {
        private static ITypeDomageRepository _ITypeDomageRepository;
        public TypeDomageController(ITypeDomageRepository TypeDomageRepository)
        {
            _ITypeDomageRepository = TypeDomageRepository;
        }
        [HttpGet]
        public List<ItemModel> GetDomageList()
        {
            return _ITypeDomageRepository.GetDomageList();
        }

    }
}
