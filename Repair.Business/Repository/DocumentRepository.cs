using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repair.Business.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private static DatabaseContext _databaseContext;

        public DocumentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Document AddDocument(DocumentModel doc)
        {
            var newDoc = new Document()
            {
                Id = Guid.NewGuid(),
                NomFichier = doc.NomFichier,
                ContenuFichier = doc.ContenuFichier,
                DateCreation = doc.DateCreation,
                CreePar = doc.Email,
                Option = doc.Option,
                OptionId = doc.OptionId,
                DossierId = doc.DossierId,
                TypeDocument = doc.TypeDocument
            };

            _databaseContext.Document.Add(newDoc);
            _databaseContext.SaveChanges();

            return newDoc;
        }

        public List<DocumentModel> GetDocumentsByDossier(Guid id)
        {
            var res = _databaseContext.Document.Where(x => x.DossierId == id)
                .Select(x => new DocumentModel()
                {
                    Id = x.Id,
                    NomFichier = x.NomFichier,
                    ContenuFichier = x.ContenuFichier,
                    DateCreation = x.DateCreation,
                    CreePar = x.CreePar,
                    Option = x.Option,
                    OptionId = x.OptionId,
                    TypeDocument = x.TypeDocument,
                    DossierId = x.DossierId
                }).ToList();
            return res;
        }

        public void RemoveDocument(Guid id)
        {
            var doc = _databaseContext.Document.FirstOrDefault(x => x.Id == id);
            if (doc != null)
            {
                _databaseContext.Document.Remove(doc);
                _databaseContext.SaveChanges();
            }
        }
    }
}
