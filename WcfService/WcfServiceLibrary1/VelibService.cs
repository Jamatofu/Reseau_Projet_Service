using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class VelibService : IVelibService
    {
        private readonly string API_KEY = "595561f861a54225f3fb5c1170b3895ac26a34e6";
        private readonly string URL_TO_API = "https://api.jcdecaux.com/vls/v1/stations?";

        public int GetNumberAvailableBike(string city, string station)
        {
            IList<Station> stationList = Create(city);
            foreach(Station item in stationList)
            {
                if(item.name == station)
                {
                    return item.available_bikes;
                }
            }

            return -1;
        }

        public IList<Station> GetStations(string city)
        {
            return Create(city);
        }


        public IList<Station> Create(string city)
        {
            WebRequest request = WebRequest.Create(CreateUrl(city));
            try
            {
                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                if (responseFromServer != string.Empty)
                {
                    return AskStation(responseFromServer);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cette ville n'existe pas.");
            }

            return null;
        }

        private IList<Station> AskStation(string responseFromServer)
        {
            dynamic stuff = JArray.Parse(responseFromServer);
            List<Station> stationList = new List<Station>();

            for (int i = 0; i < stuff.Count; i++)
            {
                dynamic tmp = stuff[i];
                string address = tmp.address;
                stationList.Add(new Station(tmp.address, tmp.status, tmp.available_bikes, tmp.name));
            }

            return stationList;
        }

        private string CreateUrl(string name)
        {
            return this.URL_TO_API + "contract=" + name + "&apiKey=" + this.API_KEY + "";
        }
    }
}
