using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CafeForDevs.Server.Handlers
{
    public abstract class Handler
    {
        protected T GetRequestBody<T>(HttpListenerContext context)
        {
            var inputStream = context.Request.InputStream;
            var inputBytes = new byte[context.Request.ContentLength64];
            inputStream.Read(inputBytes, 0, (int)context.Request.ContentLength64);
            var bodyString = Encoding.UTF8.GetString(inputBytes);
            return JsonConvert.DeserializeObject<T>(bodyString);
        }

        protected void SetResponse<T>(T model, HttpListenerContext context)
        {
            var outputStream = context.Response.OutputStream;
            var jsonString = JsonConvert.SerializeObject(model);
            var outputBytes = Encoding.UTF8.GetBytes(jsonString);
            outputStream.Write(outputBytes, 0, outputBytes.Length);
        }
    }
}
