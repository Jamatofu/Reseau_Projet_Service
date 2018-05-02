using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Service
{
    public class VelibService : IVelibService
    {
        public readonly string API_KEY = "595561f861a54225f3fb5c1170b3895ac26a34e6";
        public readonly string URL_TO_API = "https://api.jcdecaux.com/vls/v1/stations?";
        public Cache cache = new Cache();

        static Action<string, string, int> m_Event = delegate { };

        /// <summary>
        /// Récupère le nombre de vélo d'une station dans une ville
        /// </summary>
        /// <param name="city"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        public int GetNumberAvailableBike(string city, string station)
        {
            int responce = this.cache.GetNbBike(city, station);
            if (responce >= 0)
            {
                return responce;
            }

            IList<Station> stationList = Create(city);
            foreach (Station item in stationList)
            {
                if (item.name == station)
                {
                    return item.available_bikes;
                }
            }

            return -1;
        }

        /// <summary>
        /// Récupére la totalité des stations d'une ville
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public IList<Station> GetStations(string city)
        {
            IList<Station> responce = this.cache.GetStations(city);
            if (responce != null)
            {
                return responce;
            }

            responce = Create(city);
            this.cache.UpdateStations(city, responce);
            return responce;
        }

        /// <summary>
        /// Envoie une requête à l'API JcDecaux et renvoie la liste des stations d'une ville
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
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

            return new List<Station>();
        }

        /// <summary>
        /// Traite un string pour en ressortir la liste des stations
        /// </summary>
        /// <param name="responseFromServer"></param>
        /// <returns></returns>
        public IList<Station> AskStation(string responseFromServer)
        {
            dynamic stuff = JArray.Parse(responseFromServer);
            List<Station> stationList = new List<Station>();
            Station station;

            for (int i = 0; i < stuff.Count; i++)
            {
                dynamic tmp = stuff[i];
                string address = tmp.address;
                string name = tmp.name;

                station = new Station();
                station.address = address;
                station.name = name.Split('-')[1];
                station.status = tmp.status;
                station.available_bikes = tmp.available_bikes;
                stationList.Add(station);
            }

            return stationList;
        }

        /// <summary>
        /// Crée l'URL pour appeller l'API JcDecaux
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string CreateUrl(string name)
        {
            return this.URL_TO_API + "contract=" + name + "&apiKey=" + this.API_KEY + "";
        }

        public void SubscribeToAvailableBikesChanged(string city, string station, int timeForResponce)
        {
            IEventService subscriber = OperationContext.Current.GetCallbackChannel<IEventService>();
            m_Event += subscriber.NumberOfBikesChanged;


        }
    }
}
