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

        public Event AddEvent(EventModel eve)
        {
            var newEvent = new Event()
            {
                Id = Guid.NewGuid(),
                End = eve.End,
                Start = eve.Start,
                Description = eve.Description,
            };

            _databaseContext.Event.Add(newEvent); 

            _databaseContext.SaveChanges();

            return newEvent;
        }


        public List<EventModel> GetEventsByUser(Guid id)
        {
            return _databaseContext.Event.Where(x => x.UtilisateurId == id).Select(x => new EventModel()
            {
                Id = x.Id,
                Start = x.Start,
                End = x.End,
                Description= x.Description,
            }).ToList();
        }

        public  void RemoveEvent(Guid id)
        {
            var even = _databaseContext.Event.Where(x => x.UtilisateurId == id).FirstOrDefault();
            _databaseContext.Event.Remove(even);
        }
    }
   
}
