using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExmoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init
            //var api needs own private API-key and secret-key frim exchange
            var api = new ExmoApi("K-", "S-");
            //sync query
            var result = api.ApiQuery("user_info", new Dictionary<string, string>());
            //Console.WriteLine("sync result");
            //Console.WriteLine(result);
            var result2 = api.ApiQuery("user_cancelled_orders", new Dictionary<string, string> { { "limit", "100" }, { "offset", "0" } });
            //Console.WriteLine("sync result2");
            //Console.WriteLine(result2);


            //async query
            var task = api.ApiQueryAsync("user_info", new Dictionary<string, string>());
            //Console.WriteLine("async result3");
            //Console.WriteLine(task.Result);

            Task.Factory.StartNew(async () =>
            {
                var result3 = await api.ApiQueryAsync("user_cancelled_orders", new Dictionary<string, string> { { "limit", "2" }, { "offset", "0" } });
                foreach (char sym in result3){
                    Console.Write(sym);
                    if (sym == ',')
                        Console.WriteLine();
                }

                //int dateValue = ;
                Console.WriteLine($"\n___ {result3.IndexOf("date")} ____");
                
                //if (result3.Contains("date")){
                //    result3.IndexOf("date")
                //}

            
                //Console.WriteLine("async result4");
               // Console.WriteLine(result3);
            });

            Console.ReadLine();
        }
    }
}