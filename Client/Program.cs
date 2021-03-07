using Newtonsoft.Json;
using System.Net.Http;

namespace Client
{
    class Program
    {
        /// <summary>
        /// Очень хорошая программа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var newShowcaseProduct = new ShowcaseProduct
            {
                Price = 300,
                ProductId = 1,
                ShowcaseId = 2
            };

            var httpClient = new HttpClient();

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