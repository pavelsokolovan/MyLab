﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            /*tubeCollector.Add("URCUP", "Urine cup", 10);
            tubeCollector.Add("BLCUP", "Blood cup", 7);
            tubeCollector.Add("5ML", "5 ml cup", 5);*/
            
            Console.WriteLine(tubeCollector.GetString("Hello")[0]);

            string tubeCodes = tubeCollector.GetTubeCodes();
            Console.WriteLine(tubeCodes);
            /*
            foreach (string item in tubeCodes)
                Console.WriteLine(item);*/
            Console.ReadKey();
        }
    }
}