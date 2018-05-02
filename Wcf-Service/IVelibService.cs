using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Service
{
    [ServiceContract(CallbackContract = typeof(IEventService))]
    public interface IVelibService
    {
        [OperationContract]
        IList<Station> GetStations(string city);

        [OperationContract]
        int GetNumberAvailableBike(string city, string station);

        [OperationContract]
        void SubscribeToAvailableBikesChanged(string city, string station, int timeForResponce);
    }
}
