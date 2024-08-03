using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowExample
{
    [TestFixture]
    internal class Nested
    {
        [Test]
        public void nestedget()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users?page=2",Method.Get);
            var response = client.Execute(request);
            var res = response.Content;
            var jsonserialization = JsonConvert.DeserializeObject<nest>(res);

            Console.WriteLine(jsonserialization.page);

            Console.WriteLine(jsonserialization.support.url);

            foreach(var data in jsonserialization.data)
            {
                Console.WriteLine(data.first_name);
            }

        }


    }

    class data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    class support
    {
        public string url { get; set; }
        public string text { get; set; }

    }

    class nest
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<data> data { get; set; }
        public support support { get; set; }

    }

}
