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
                UtilisateurId = eve.UserId,
            };

            _databaseContext.Event.Add(newEvent);

            _databaseContext.SaveChanges();

            return newEvent;
        }


        public List<RendezVousModel> GetEventsByUser(Guid id)
        {
            return _databaseContext.Event.Include(x => x.TypeRendezVous)
                    .Where(x => x.UtilisateurId == id).Select(x => new RendezVousModel()
                    {
                        Id = x.Id,
                        UserId = x.UtilisateurId,
                        Description = x.Description,
                        End = x.End,
                        Start = x.Start,
                        TypeRendezVous = new ItemModel() { Id = x.TypeRendezVousId, Nom = x.TypeRendezVous.Nom },

                    }
                    ).ToList();
        }


        public void RemoveEvent(Guid id)
        {
            var even = _databaseContext.Event.Where(x => x.UtilisateurId == id).FirstOrDefault();
            _databaseContext.Event.Remove(even);

            _databaseContext.SaveChanges();
        }


    }
}
