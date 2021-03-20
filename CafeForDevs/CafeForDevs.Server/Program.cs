using CafeForDevs.Server.Application;
using CafeForDevs.Server.Handlers;
using System;
using System.Collections.Generic;
using System.Net;

namespace CafeForDevs.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseUrl = new Uri("http://localhost:37820/");

            var httpListener = new HttpListener();
            httpListener.Prefixes.Add(baseUrl.ToString());

            var handlers = new List<IHandler>();

            var order = new Order();
            handlers.Add(new MenuHandler(order));
            handlers.Add(new OrderHandler(order));


            foreach (var handler in handlers)
            {
                var handlerUrl = new Uri(baseUrl, handler.Path + "/");
                httpListener.Prefixes.Add(handlerUrl.ToString());
            }

            var router = new Router(handlers);

            var application = new ServerApplication(httpListener, router);
            application.Start();
        }
    }
}
