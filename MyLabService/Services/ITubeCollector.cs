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
        bool Add(string code, string name, int volume);

        /*[OperationContract]
        string GetTubeCodes();*/

        /*/ TEMP
        [OperationContract]
        string[] GetString(string st);*/
    }
}
