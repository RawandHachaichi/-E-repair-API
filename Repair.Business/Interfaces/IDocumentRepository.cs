using Microsoft.AspNetCore.Http;
using Repair.Business.Models;
using Repair.Database.Entities;


namespace Repair.Business.Interfaces
{
    public interface IDocumentRepository
    {
        public Document AddDocument(string option, Guid optionId, Guid dossierId, IFormFile file);
        public List<DocumentModel> GetDocumentsByDossier(Guid id);
        public  void RemoveDocument(Guid id);
    }
}
