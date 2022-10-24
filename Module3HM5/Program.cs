using System;
using System.Text;
using System.Text.Json;

namespace Module3HM5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.WhenAll(HelloWorld()).GetAwaiter().GetResult();
            Console.WriteLine(HelloWorld());
        }
        
        private static string hellopath = @"Module3HM5/Hello.json";
        private static string worldpath = @"Module3HM5/World.json";
        private static string filepath = "helloworld.json";

        
        
        static async Task Hello()
        {
            using (FileStream fs = File.OpenRead(hellopath))
            {
                byte[] buffer = new byte[fs.Length];
                await fs.ReadAsync(buffer, 0, buffer.Length);
                string textFromHello = Encoding.Default.GetString(buffer);
            }
        }

        static async Task World()
        {
            using (FileStream fs = File.OpenRead(worldpath))
            {
                byte[] buffer = new byte[fs.Length];
                await fs.ReadAsync(buffer, 0, buffer.Length);
                string textFromWorld = Encoding.Default.GetString(buffer);
            }
        }

        private static async Task HelloWorld()
        {
            using (FileStream fs = new FileStream(hellopath, FileMode.OpenOrCreate))
            {
                Files? files = await JsonSerializer.DeserializeAsync<Files>(fs);
            }
            
            using (FileStream fs = new FileStream(worldpath, FileMode.OpenOrCreate))
            {
                Files? files = await JsonSerializer.DeserializeAsync<Files>(fs);
            }
            Task.WhenAll(World(), Hello()).GetAwaiter().GetResult();
            var result = string.Concat(HelloWorld());
        }
    }
    
}