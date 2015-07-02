using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyLabService.Services
{
    [ServiceContract]
    public interface ITubeCollector
    {
        [OperationContract]
        void Add(string code, string name, double volume);

        [OperationContract]
        string GetTubeCodes();

        // TEMP
        [OperationContract]
        string[] GetString(string st);
    }
}
