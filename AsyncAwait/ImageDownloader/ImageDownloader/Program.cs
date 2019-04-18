using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImageDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the image url");
            var uri = Console.ReadLine();
            DownloadImage(uri).Wait();
        }

        public static async Task DownloadImage(string uri)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();

                        var content = response.Content.ReadAsByteArrayAsync();
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            using (var fileStream = new FileStream("test.jpg", FileMode.OpenOrCreate))
                            {
                                stream.Position = 0;
                                await stream.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load the image: {0}", ex.Message);
            }
        }
    }
}
