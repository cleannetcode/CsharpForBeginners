using System.Net;

namespace CafeForDevs.Server.Handlers
{
    public interface IHandler
    {
        string Path { get; }
        void Handle(HttpListenerContext context);
    }
}
