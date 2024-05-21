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

        [HttpPost("/api/Document")]
        public IActionResult AddDocument([FromForm] DocumentModel documentModel, IFormFile file)
        {
            var document = _IDocumentRepository.AddDocument(documentModel, file); // Passez le paramètre file
            if (document == null)
            {
                return BadRequest("Le fichier est invalide.");
            }
            return Ok(document);
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
