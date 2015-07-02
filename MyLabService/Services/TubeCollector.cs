using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService.Services
{
    public class TubeCollector: ITubeCollector
    {
        private Dictionary<string, Tube> tubes;      // Tubes collection

        // Constructor
        public TubeCollector()
        {
            tubes = new Dictionary<string, Tube>();
            Console.WriteLine(GetHashCode());
        }
        
        // Method to Add new tube
        public void Add(string code, string name, double volume)
        {
            tubes.Add(code, new Tube(code, name, volume));            
        }

        // Method to get collection of tube codes
        public string GetTubeCodes()
        {
            string[] array = new string[tubes.Count];
            Console.WriteLine(tubes.Count);
            int i = 0;/*
            foreach(string item in tubes.Keys)
            {
                array[i] = item;
            }
            string st2 = array[0];
            Console.WriteLine(st2);*/
            return "yee";
        }

        // TEMP
        public string[] GetString(string st)
        {
            /*Dictionary<string, string> dic = new Dictionary<string,string>;
            dic.Add(st, st);*/

            return new string[] {st};
        }
    }
}
