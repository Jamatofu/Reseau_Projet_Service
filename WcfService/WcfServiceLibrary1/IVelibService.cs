using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    [ServiceContract]   
    public interface IVelibService
    {
        [OperationContract]
        IList<Station> GetStations(string city);

        [OperationContract]
        int GetNumberAvailableBike(string city, string station);
    }
}
