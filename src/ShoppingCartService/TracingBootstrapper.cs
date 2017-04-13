using Nancy;
using Nancy.Configuration;

namespace ShoppingCartService
{
    public class TracingBootstrapper : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment env)
        {
            env.Tracing(enabled: true, displayErrorTraces: true);
        }
    }
}
