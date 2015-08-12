using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyLabService.Services;
using System.Data;

namespace MyLabHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            // Add new rows in DB
            /*TubeCollector tubeCollector = new TubeCollector();
            //tubeCollector.Add("URCUP", "Urine cup", 10);
            tubeCollector.Add("BLCUP", "Blood cup", null);
            //tubeCollector.Add("5ML", "5 ml cup", 5);            
            Console.ReadKey();*/

            // Try to find code in DB
            /*TubeCollector tubeCollector = new TubeCollector();
            Console.WriteLine(tubeCollector.Contains("URCUP"));
            Console.ReadKey();*/

            // Update existing row
            /*TubeCollector tubeCollector = new TubeCollector();
            tubeCollector.Add("URCUP", "Urine cup", 10);
            tubeCollector.Update("URCUP", "Urine cup updated", 99);
            Console.ReadKey();*/

            // Get DataSet For Table
            /*TubeCollector tubeCollector = new TubeCollector();
            DataSet dataSet = tubeCollector.GetDataSetForTable("TUBE", "R");
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
