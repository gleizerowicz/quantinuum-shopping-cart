using System;
using System.Collections.Generic;

namespace ShoppingCartService.EventStore
{
    public class EventStore : IEventStore
    {
        public IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber)
        {
            throw new NotImplementedException();
        }

        public void Raise(string eventName, object content)
        {
            throw new NotImplementedException();
        }
    }
}