using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_HW_25012023
{
    public class Ex5
    {
        private readonly static Ex5 _EX5 = new Ex5();
        public static Ex5 EX5
        {
            get { return _EX5; }
        }
        public async Task<string> GetDataAsync()
        {

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://www.ynet.co.il/home/0,7340,L-8,00.html");
                response.EnsureSuccessStatusCode(); // Throw an exception if the request failed
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
        }
    }
}
