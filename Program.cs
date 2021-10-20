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
        private static string asmaUlHusna = $"http://api.aladhan.com/asmaAlHusna/";
        private static string prayerTimeApi = $"http://api.aladhan.com/v1/timingsByCity?city=&country=&method=8";
        private static void changeAsmaAlHusna(int number)
        {
            asmaUlHusna = $"http://api.aladhan.com/asmaAlHusna/{number}";
        }
        private static void changePrayerTimeApi(string countrie, string citie)
        {
            prayerTimeApi = $"http://api.aladhan.com/v1/timingsByCity?city={citie}&country={countrie}&method=8";
        }
        static async Task Main(string[] args)
        {
            Console.Write($"Please enter 1~99: ");
            
            var numberName = int.Parse(Console.ReadLine());

            Console.Write($"Enter countrie: ");
            string countries = Console.ReadLine();
            
            Console.Write($"Enter cities: ");
            string cities = Console.ReadLine();
            changeAsmaAlHusna(numberName);
            changePrayerTimeApi(countries, cities);
            
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
