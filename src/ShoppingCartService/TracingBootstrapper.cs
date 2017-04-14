using System;
using Nancy;
using Nancy.Configuration;
using Nancy.Bootstrapper;
using Nancy.ModelBinding;
using Nancy.ErrorHandling;

namespace ShoppingCartService
{
    public class TracingBootstrapper : DefaultNancyBootstrapper, IStatusCodeHandler
    {
        public override void Configure(INancyEnvironment env)
        {
            env.Tracing(enabled: true, displayErrorTraces: true);
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            //Tuple<string, string>[] headers = {
            //Tuple.Create<string, string>("Cache-Control", "no-cache"),
            //Tuple.Create<string, string>("Content-Length", "0")
            //};

            var response = new Response();

            response.WithStatusCode(HttpStatusCode.OK);
                    //.WithHeaders(headers)
                    //.WithContentType(string.Empty);

            context.Response = new HeadResponse(response);
        }

    }
}
