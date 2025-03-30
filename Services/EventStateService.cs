using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventEase.Models;

namespace EventEase.Services
{
    public class EventStateService
    {
        private readonly EventList _eventsList = new();
        private Event _currentEvent = new();

        public event Func<Task>? StateChanged;

        // Gets the current event
        public Task<Event> GetCurrentEventAsync() => Task.FromResult(_currentEvent);

        // Sets the current event
        public async Task SetEventAsync(Event newEvent)
        {
            _currentEvent = newEvent;
            await NotifyStateChangedAsync();
        }

        // Adds an event to the list
        public async Task AddEventAsync(Event newEvent)
        {
            _eventsList.Events.Add(newEvent);
            await NotifyStateChangedAsync();
        }

        // Removes an event from the list
        public async Task RemoveEventAsync(Event eventToRemove)
        {
            _eventsList.Events.Remove(eventToRemove);
            await NotifyStateChangedAsync();
        }
        
        public Task<EventList> GetEventListAsync() => Task.FromResult(_eventsList);

        // Asynchronous state change notification
        private async Task NotifyStateChangedAsync()
        {
            if (StateChanged != null)
            {
                await StateChanged.Invoke();
            }
            await Task.Yield(); // Ensures async execution without blocking UI
        }
    }
}
