using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Service
{
    interface IEventService
    {
        [OperationContract(IsOneWay = true)]
        void NumberOfBikesChanged(string city, string station, int nb);
    }
}
