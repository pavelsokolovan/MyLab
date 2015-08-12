using MyLabService.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyLabClient
{
    // Additional class to get access to services  
    public class TubeCollectorProxy : ITubeCollector
    {
        private ITubeCollector tubeCollectorChannel;       // channel

        // Constructor
        public TubeCollectorProxy()
        {
            Uri adress = new Uri("http://localhost:8080/");          // A - adress
            BasicHttpBinding binding = new BasicHttpBinding();       // B - binfding
            EndpointAddress endpoint = new EndpointAddress(adress);  // endpoint

            // ChannelFactory creation
            ChannelFactory<ITubeCollector> channelFactory = new ChannelFactory<ITubeCollector>(binding, endpoint);    // ABC
            tubeCollectorChannel = channelFactory.CreateChannel();
        }

        // Method to Add new row
        public bool Add(string code, string name, int volume)
        {
            return tubeCollectorChannel.Add(code, name, volume);
        }

        // Method to Update row
        public bool Update(string code, string name, int volume)
        {
            return tubeCollectorChannel.Update(code, name, volume);
        }

        // Method to checks if code is presented in DB
        public bool Contains(string code)
        {
            return tubeCollectorChannel.Contains(code);
        }

        // Return DataSet item for proper Table
        // Code is used for searching rows with proper code
        public DataSet GetDataSetForTable(string tableNameInDB, string code)
        {
            return tubeCollectorChannel.GetDataSetForTable(tableNameInDB, code);
        }
    }
}
