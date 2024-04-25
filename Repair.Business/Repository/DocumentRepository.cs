using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        public Document AddDocument(string option, Guid optionId, Guid dossierId, IFormFile file)
        {
            // Vérifier si le fichier est valide
            if (file == null || file.Length <= 0)
            {
                // Gérer le cas où le fichier est invalide en retournant null

                return null;
            }

            // Utiliser un MemoryStream pour lire le contenu du fichier
            using (var stream = new MemoryStream())
            {
                // Copier le contenu du fichier dans le MemoryStream (asynchrone)
                file.CopyToAsync(stream); // Il manque ici un "await" pour attendre la fin de l'opération

                // Convertir le contenu du MemoryStream en tableau d'octets
                var fileContent = stream.ToArray();

                // Créer un nouvel objet Document avec les informations fournies
                var document = new Document
                {
                    Id = Guid.NewGuid(),
                    NomFichier = file.FileName,
                    ContenuFichier = fileContent,
                    TypeDocument = file.ContentType,
                    DateCreation = DateTime.Now,
                    Option = option,
                    OptionId = optionId,
                    DossierId = dossierId
                };

                // Ajouter le document au contexte de base de données
                _databaseContext.Document.Add(document);

                // Enregistrer les modifications dans la base de données
                _databaseContext.SaveChanges();

                // Retourner l'objet document créé
                return document;
            }
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
