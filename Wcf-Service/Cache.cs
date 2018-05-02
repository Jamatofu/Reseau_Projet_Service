using System;
using System.Collections.Generic;

namespace Wcf_Service
{
    [Serializable]
    public class Cache
    {
        public IDictionary<string, Tuple<DateTime, IList<Station>>> storedStations; // ville <Date mise en cache, liste des stations>
        public TimeSpan lifespanCache;

        public Cache()
        {
            lifespanCache = new TimeSpan(0, 10, 0);
            this.storedStations = new Dictionary<string, Tuple<DateTime, IList<Station>>>();
        }

        /// <summary>
        /// Permet de récupérer les stations d'une ville
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public IList<Station> GetStations(string city)
        {
            if (!storedStations.TryGetValue(city, out Tuple<DateTime, IList<Station>> responce))
            {
                return null;
            }

            if (this.lifespanCache > DateTime.Now - responce.Item1)
            {
                return responce.Item2;
            }
            else
            {
                storedStations.Remove(city);
            }

            return null;
        }


        public int GetNbBike(string city, string station)
        {
            if (!storedStations.TryGetValue(city, out Tuple<DateTime, IList<Station>> responce))
            {
                return -1;
            }

            if (this.lifespanCache > DateTime.Now - responce.Item1)
            {
                foreach(Station stationItem in responce.Item2)
                {
                    if (station.Equals(stationItem.name))
                    {
                        return stationItem.available_bikes;
                    }
                }
            }
            else
            {
                storedStations.Remove(city);
            }

            return -1;
        }

        public void UpdateNbBike(string station, int nbBike)
        {
            foreach (Tuple<DateTime, IList<Station>> tuple in storedStations.Values)
            {
                foreach(Station stationItem in tuple.Item2)
                {
                    if(station.Equals(stationItem.name))
                    {
                        stationItem.available_bikes = nbBike;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Permet d'insérer une station dans le cache ou bien de mettre à jour une station existante
        /// </summary>
        /// <param name="city">la ville</param>
        /// <param name="stations">la station</param>
        public void UpdateStations(string city, IList<Station> stations)
        {
            this.storedStations.Add(city, new Tuple<DateTime, IList<Station>>(DateTime.Now, stations));
        }
    }
}
