using Repair.Business.Models;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Interfaces
{
    public interface IEventRepository
    {
        public List<EventModel> GetEventsByUser(Guid id);
        public Event AddEvent(EventModel eve);
        public void RemoveEvent(Guid id);
    }
}
