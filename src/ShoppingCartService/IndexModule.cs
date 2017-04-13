using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartService
{
    public class IndexModule : NancyModule
    {
        dynamic IndexPage() { return HttpStatusCode.OK.ToString() + " = 200"; } // OK = 200

        public IndexModule()
        {
            Get("/", parameters =>
            {
                return IndexPage();
            });
        }
    }
}
