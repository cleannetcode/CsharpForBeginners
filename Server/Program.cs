using System.Net;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:51369/");
            httpListener.Start();

            while (true)
            {
                var requestContext = httpListener.GetContext();
                requestContext.Response.StatusCode = 200; //OK

                var stream = requestContext.Response.OutputStream;

                var text = "test message";
                var bytes = Encoding.UTF8.GetBytes(text);
                stream.Write(bytes, 0, bytes.Length);
                requestContext.Response.Close();
            }

            httpListener.Stop();
            httpListener.Close();
        }
    }
}
