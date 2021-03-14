using CafeForDevs.Server.Handlers;
using System.Collections.Generic;
using System.Linq;

namespace CafeForDevs.Server
{
    public class Router
    {
        private readonly List<IHandler> _handlers;

        public Router(List<IHandler> handlers)
        {
            _handlers = handlers;
        }

        public IHandler Get(string path)
        {
            return _handlers.SingleOrDefault(x => x.Path == path);
        }
    }
}
