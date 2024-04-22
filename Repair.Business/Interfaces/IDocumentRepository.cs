using Repair.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Interfaces
{
    public interface IDocumentRepository
    {
        public List<DocumentModel> GetDocumentsByDossier(Guid id);
   
        public Document AddDocument(DocumentModel doc);
        public void RemoveDocument(Guid id);
    }
}
