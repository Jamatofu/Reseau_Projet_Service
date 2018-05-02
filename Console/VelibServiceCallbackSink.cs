using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVelib
{
    internal class VelibServiceCallbackSink : VelibService.IVelibServiceCallback
    {
        public void NumberOfBikesChanged(string city, string station, int nb)
        {
            Console.WriteLine("La station " + station + " dans " + city + " a " + nb + " velo(s)");
        }
    }
}
