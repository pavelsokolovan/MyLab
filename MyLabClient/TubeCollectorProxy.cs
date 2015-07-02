using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyLabService.Services;

namespace MyLabClient
{
    // Proxy Class for TubeCollector
    class TubeCollectorProxy: ITubeCollector
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

        // Method to Add new tube
        public void Add(string code, string name, double volume)
        {
            tubeCollectorChannel.Add(code, name, volume);
        }

        // Method to get collection of tube codes
        public string GetTubeCodes()
        {
            return tubeCollectorChannel.GetTubeCodes();
        }

        // TEMP
        public string[] GetString(string st)
        {
            return tubeCollectorChannel.GetString(st);
        }
    }
}
