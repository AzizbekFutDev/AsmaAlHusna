using System;
using System.Text.Json;
using System.Threading.Tasks;
using lesson10.Dto.PrayerTime;
using lesson10.Dto.AsmaAlHusna;
using lesson10.Dto.User;
using lesson10.Services;

namespace lesson10
{
    class Program
    {
        private static string usersApi = "https://randomuser.me/api/";
        static async Task Main(string[] args)
        {
            var numberName = int.Parse(Console.ReadLine());

            string asmaUlHusna = $"http://api.aladhan.com/asmaAlHusna/{numberName}";
            string cities = Console.ReadLine();
            string countries = Console.ReadLine();
            
            string prayerTimeApi = $"http://api.aladhan.com/v1/timingsByCity?city={cities}&country={countries}&method=8";
            var httpService = new HttpClientService();
            var result = await httpService.GetObjectAsync<PrayerTime>(prayerTimeApi);
            var resultAsmaUlHusna = await httpService.GetObjectAsync<Root>(asmaUlHusna);

            if(result.IsSuccess)
            {
                var settings = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(result.Data, settings);
                Console.WriteLine($"{json}");
            }
            else
            {
                Console.WriteLine($"{result.ErrorMessage}");
            }
            if(resultAsmaUlHusna.IsSuccess)
            {
                var settings2 = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var json2 = JsonSerializer.Serialize(resultAsmaUlHusna.Data, settings2);
                Console.WriteLine($"{json2}");
            }
            else
            {
                Console.WriteLine($"{resultAsmaUlHusna}");
                
            }
            
        }
        static async Task Main_user(string[] args)
        {
            var httpService = new HttpClientService();
            var result = await httpService.GetObjectAsync<User>(usersApi);

            if(result.IsSuccess)
            {
                Console.WriteLine($"{result.Data.Results[0].Name.First}");
            }
            else
            {
                Console.WriteLine($"{result.ErrorMessage}");
            }
            
        }
    }
}
