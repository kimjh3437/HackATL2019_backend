using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackATL_EEVM_backend.Models.Entities;
using HackATL_EEVM_backend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackATL_EEVM_backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaViewModel AgendaViewModel;

        public AgendaController(IAgendaViewModel agendaViewModel)
        {
            AgendaViewModel = agendaViewModel;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AgendaEvents>> List()
        {
            return AgendaViewModel.GetAllEvents().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AgendaEvents> GetEvents(string id)
        {
            AgendaEvents events = AgendaViewModel.GetEvents(id);

            if (events == null)
                return NotFound();

            return events;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AgendaEvents> Create([FromBody]AgendaEvents events)
        {
            AgendaViewModel.AddEvents(events);
            return CreatedAtAction(nameof(GetEvents), new { events.Id }, events);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] AgendaEvents events)
        {
            try
            {
                AgendaViewModel.UpdateEvents(events);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string id)
        {
            AgendaEvents events = AgendaViewModel.RemoveEvents(id);

            if (events == null)
                return NotFound();

            return Ok();
        }
    }
}
