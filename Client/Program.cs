using Newtonsoft.Json;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var newShowcaseProduct = new ShowcaseProduct
            {
                Price = 100,
                ProductId = 1,
                ShowcaseId = 2
            };

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("TEST_HEADER", "TEST VALUE");

            var json = JsonConvert.SerializeObject(newShowcaseProduct);
            var jsonContent = new StringContent(json);

            var response = httpClient.PostAsync("http://localhost:51369", jsonContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            System.Console.WriteLine(content);
        }
    }

    public class ShowcaseProduct
    {
        public int ShowcaseId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
    }
}