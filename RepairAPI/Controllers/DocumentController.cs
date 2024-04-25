using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;
using Repair.Database.Entities;


namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private static IDocumentRepository _IDocumentRepository;

        public DocumentController(IDocumentRepository DocumentRepository)
        {
            _IDocumentRepository = DocumentRepository;
        }

        [HttpPost("/optionId/option/dossierId/file")]
        public Document AddDocument(string option, Guid optionId, Guid dossierId, IFormFile file)
        {
            return _IDocumentRepository.AddDocument(option, optionId,dossierId,file);
        }

        [HttpGet("/GetDocument/{id})")]
        public List<DocumentModel> GetDocumentsByDossier(Guid id)
        {
            return _IDocumentRepository.GetDocumentsByDossier(id);
        }

        [HttpDelete("/DeleteDocument/{id}")]
         public void DeleteDocument(Guid id)
        {
            _IDocumentRepository.RemoveDocument(id);
        }

    }
}
