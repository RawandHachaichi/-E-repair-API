using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocumentController : ControllerBase
    {
        private static ITypeDocumentRepository _ITypeDocumentRepository;
        public TypeDocumentController(ITypeDocumentRepository TypeDocumentRepository)
        {
            _ITypeDocumentRepository = TypeDocumentRepository;
        }

        [HttpGet]
        public List<ItemModel> GetType() {
            return _ITypeDocumentRepository.GetTypeDocument();
                }
    }
}
