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
        public List<RendezVousModel> GetEventsByUser(Guid id);
        public Event AddEvent(RendezVousModel eve);
        public void RemoveEvent(Guid id);
    }
}
