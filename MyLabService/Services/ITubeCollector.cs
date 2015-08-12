using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace MyLabService.Services
{
    [ServiceContract]
    public interface ITubeCollector
    {
        [OperationContract]
        bool Add(string code, string name, int volume);             // Add a new row to DB

        [OperationContract]
        bool Update(string code, string name, int volume);          // Update an existing row in DB

        [OperationContract]
        bool Contains(string code);                                 // Checks if code is presented in DB

        // Return DataSet item for proper Table
        // Code is used for searching rows with proper code
        [OperationContract]
        DataSet GetDataSetForTable(string tableNameInDB, string code);  
    }
}
