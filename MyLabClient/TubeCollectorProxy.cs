using MyLabService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyLabClient
{
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

        // Method to Add new tube
        public bool Add(string code, string name, int volume)
        {
            return tubeCollectorChannel.Add(code, name, volume);
        }

        // Method to checks if code is presented in DB
        public bool Contains(string code)
        {
            return tubeCollectorChannel.Contains(code);
        }
    }
}
