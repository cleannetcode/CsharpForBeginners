using Newtonsoft.Json;
using System;
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
                var requestStream = requestContext.Request.InputStream;
                var requestBytes = new byte[requestContext.Request.ContentLength64];
                requestStream.Read(requestBytes, 0, (int)requestContext.Request.ContentLength64);
                var requestBodyString = Encoding.UTF8.GetString(requestBytes);
                Console.WriteLine(requestBodyString);

                var requestObject = JsonConvert.DeserializeObject<ShowcaseProduct>(requestBodyString);

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

    // Model, Request, ResourceModel, Dto
    public class ShowcaseProductModel
    {
        public int ShowcaseId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
    }

    public class ShowcaseProduct
    {
        public ShowcaseProduct()
        {

        }

        public int ShowcaseId { get; set; }
        public Product Product { get; set; }

        public int Price { get; set; }
    }

    public class Product
    {

    }
}
