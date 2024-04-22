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
        public List<EventModel> GetEventsById(Guid id)
        {
            return _IEventRepository.GetEventsByUser(id);
        }


        [HttpPost("/AddEvent")]
        public Event AddEvent(EventModel eve)
        {
            return _IEventRepository.AddEvent(eve);
        }

        [HttpDelete]
        public void DeleteEvent(Guid id)
        {
             _IEventRepository.RemoveEvent(id);
        }
    }
}
