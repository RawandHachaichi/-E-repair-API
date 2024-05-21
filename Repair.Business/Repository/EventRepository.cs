using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Repository
{
    public class EventRepository : IEventRepository
    {
        private static DatabaseContext _databaseContext;
        public EventRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }

        public Event AddEvent(RendezVousModel eve)
        {

            var newEvent = new Event()
           
            {
                Id = Guid.NewGuid(),
                End = eve.End,
                Start = eve.Start,
                Description = eve.Description,
                TypeRendezVousId = eve.TypeRendezVous.Id,
                DossierId = eve.DossierId,
           
            };

            _databaseContext.Event.Add(newEvent);

            _databaseContext.SaveChanges();

            return newEvent;
        }
        /*public Event Planifier(RendezVousModel eve, Guid? statusId)
        {
            var Statut = _databaseContext.Dossiers
              
                .FirstOrDefault(x => x.DossierStatusId == statusId);


            if (Statut != null)
            {
                // Création d'un nouvel événement
                var newEvent = new Event()
                {
                    Id = Guid.NewGuid(),
                    End = eve.End,
                    Start = eve.Start,
                    Description = eve.Description,
                    TypeRendezVousId = eve.TypeRendezVous.Id,
                    DossierId = eve.Id, // Utilisation de l'ID du dossier récupéré
                };


                // Ajout du nouvel événement à la table Events
                _databaseContext.Event.Add(newEvent);

                // Sauvegarde des modifications dans la base de données
                _databaseContext.SaveChanges();

                return newEvent;
            }

            return null; // Statut de dossier rejeté non trouvé
        }*/



        public List<RendezVousModel> GetEventsByUser(Guid id)
        {
            return _databaseContext.Event.Include(x => x.TypeRendezVous)
                .Include(x => x.dossier)
                    .Where(x => x.dossier.UtilisateurId == id).Select(x => new RendezVousModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        End = x.End,
                        Start = x.Start,
                        TypeRendezVous = new ItemModel { Id = x.TypeRendezVousId, Nom = x.TypeRendezVous.Nom },

                    }
                    ).ToList();
        }
        public List<RendezVousModel> GetEventsByDossier(Guid id)
        {
            return _databaseContext.Event.Include(x => x.TypeRendezVous)

                    .Where(x => x.DossierId == id).Select(x => new RendezVousModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        End = x.End,
                        Start = x.Start,
                        TypeRendezVous = new ItemModel { Id = x.TypeRendezVousId, Nom = x.TypeRendezVous.Nom },

                    }
                    ).ToList();
        }


        public void RemoveEvent(Guid userId)
        {
            var even = _databaseContext.Event.Where(x => x.dossier.UtilisateurId == userId).FirstOrDefault();
            if (even != null)
            {

                _databaseContext.Event.Remove(even);

                _databaseContext.SaveChanges();
            }
        }


    }
}
