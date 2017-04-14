using Nancy;

namespace ShoppingCartService
{
    public class EventsStoreModule : NancyModule
    {
        public EventsStoreModule(IEventStore eventStore) : base("/events")
        {
            Get("/", _ =>
            {
                long firstEventSequenceNumber, lastEventSequenceNumber;
                if (!long.TryParse(this.Request.Query.start.Value,
                  out firstEventSequenceNumber))
                    firstEventSequenceNumber = 0;
                if (!long.TryParse(this.Request.Query.end.Value,
                  out lastEventSequenceNumber))
                    lastEventSequenceNumber = long.MaxValue;

                return
                  eventStore.GetEvents(
                    firstEventSequenceNumber,
                    lastEventSequenceNumber);
            });
        }
    }
}
