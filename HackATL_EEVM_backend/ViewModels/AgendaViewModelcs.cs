using HackATL_EEVM_backend.Models.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackATL_EEVM_backend.ViewModels
{
    public interface IAgendaViewModel
    {
        void AddEvents(AgendaEvents events);
        void UpdateEvents(AgendaEvents events);
        AgendaEvents RemoveEvents(string key);
        AgendaEvents GetEvents(string id);
        IEnumerable<AgendaEvents> GetAllEvents();
        

    }
    public class AgendaViewModelcs : IAgendaViewModel
    {
        private static ConcurrentDictionary<string, AgendaEvents> Events =
           new ConcurrentDictionary<string, AgendaEvents>();

        public AgendaViewModelcs()
        {
            AddEvents(new AgendaEvents { Id = Guid.NewGuid().ToString(), Text = "First item11", Time = "10:00 PM", Location = "GBS2021", Type = "Food", Day = "FRI", Description = "This is an item description." });
            AddEvents(new AgendaEvents { Id = Guid.NewGuid().ToString(), Text = "First item22", Time = "10:00 PM", Location = "GBS2022", Type = "Food", Day = "PRE", Description = "This is an item description." });
            AddEvents(new AgendaEvents { Id = Guid.NewGuid().ToString(), Text = "First item33", Time = "10:00 PM", Location = "GBS2023", Type = "Food", Day = "SUN", Description = "This is an item description." });
            
        }

        public IEnumerable<AgendaEvents> GetAllEvents()
        {
            return Events.Values;
        }

        public void AddEvents(AgendaEvents events)
        {
            events.Id = Guid.NewGuid().ToString();
            Events[events.Id] = events;

            //var user = _context.Users.SingleOrDefault(x => x.Username == username);
           

        }

        public AgendaEvents GetEvents(string id)
        {
            AgendaEvents Event;
            Events.TryGetValue(id, out Event);

            return Event;
        }

        public AgendaEvents RemoveEvents(string id)
        {
            AgendaEvents Event;
            Events.TryRemove(id, out Event);

            return Event;
        }

        public void UpdateEvents(AgendaEvents events)
        {
            Events[events.Id] = events;
        }


    }
}
