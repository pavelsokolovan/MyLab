using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyLabService.Services;

namespace MyLabHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            /*TubeCollector tubeCollector = new TubeCollector();
            tubeCollector.Add("URCUP", "Urine cup", 10);
            tubeCollector.Add("BLCUP", "Blood cup", 7);
            tubeCollector.Add("5ML", "5 ml cup", 5);
            /*foreach (string item in tubeCollector.GetTubeCodes())
                Console.WriteLine(item);
            Console.ReadKey();*/

            Uri adress = new Uri("http://localhost:8080/");                     // A - adress
            BasicHttpBinding binding = new BasicHttpBinding();                  // B - binfding
            Type contract = typeof(ITubeCollector);                             // C - contract
            Type serviceType = typeof(TubeCollector);

            // Host provider
            ServiceHost host = new ServiceHost(serviceType);

            // End point adding
            host.AddServiceEndpoint(contract, binding, adress);

            host.Open();

            Console.WriteLine("Host is ready");
            Console.ReadKey();

            host.Close();
        }
    }
}
