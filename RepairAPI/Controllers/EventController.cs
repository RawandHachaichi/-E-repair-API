using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database.Entities;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static IEventRepository _IEventRepository;

        public EventController(IEventRepository EventRepository)
        {
            _IEventRepository = EventRepository;
        }


        [HttpGet("/Event/{id}")]
        public List<RendezVousModel> GetEventsById(Guid id)
        {
            return _IEventRepository.GetEventsByUser(id);
        }


        [HttpPost("/AddEvent")]
        public Event AddEvent(RendezVousModel eve)
        {
            return _IEventRepository.AddEvent(eve);
        }

        [HttpDelete("/api/Event/{userId}")]
        public void DeleteEvent(Guid userId)
        {
            _IEventRepository.RemoveEvent(userId);
        }


        [HttpGet("/api/GetEventByDossier/{id}")]
        public List<RendezVousModel> GetEventsByDossierI(Guid id)
        {
            return _IEventRepository.GetEventsByDossier(id);
        }

       /* [HttpPost("/api/Plan")]
        public Event Planifier (RendezVousModel eve)
        {
            return _IEventRepository.Planifier(eve);
        }*/

    }
}
