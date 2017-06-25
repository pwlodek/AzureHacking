using Backend.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.AddNewItem();

            Console.ReadKey();
        }

        private int _count;

        private void AddNewItem()
        {
            while (true)
            {
                _count++;

                TodoItem item = new TodoItem()
                {
                    Name = $"Item {_count}",
                    Completed = false,
                    DueDate = DateTime.Now,
                    UserName = "Piotrek"
                };
                String json = JsonConvert.SerializeObject(item);
                HttpClient client = new HttpClient();

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                client.PostAsync("http://localhost:50682/api/items", content);

                Console.WriteLine("Sent item.");
                Console.ReadKey();
            }
        }
    }
}
