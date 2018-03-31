using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using ConsoleVelib.ServiceReference1;

namespace ConsoleVelib
{
    /// <summary>
    /// Enumération des différentes commandes disponibles
    /// </summary>
    enum AvailableCommand
    {
        [Description("Affiche la description de chaque commande")]
        HELP,
        [Description("Ferme le programme")]
        EXIT,
        [Description("Stations d'une ville")]
        STATION,
        [Description("Nombre de vélos disponibles à une station")]
        AVAILABLE_BIKES,
        [Description("Commande inutile pour l'utilisateur")]
        NONE
    }

    public class Commande
    {
        public ServiceReference1.Service1Client client;

        public Commande()
        {
            this.client = new ServiceReference1.Service1Client();
            GetInput();
        }

        /// <summary>
        /// Récupère l'entrée de l'utilisateur (commandes...) et la traite
        /// </summary>
        public void GetInput()
        {
            AvailableCommand currentCommand;
            string[] splitCommand;
            string command;
            Boolean continuer = true;

            while (continuer)
            {
                Console.Write("Commande : ");
                command = Console.ReadLine();

                splitCommand = command.Split(' ');

                if (Enum.IsDefined(typeof(AvailableCommand), splitCommand[0].ToUpper()))
                {
                    currentCommand = (AvailableCommand)Enum.Parse(typeof(AvailableCommand), splitCommand[0].ToUpper());
                }
                else
                {
                    currentCommand = AvailableCommand.NONE;
                }

                switch (currentCommand)
                {
                    case AvailableCommand.HELP:
                        PrintHelp();
                        break;
                    case AvailableCommand.EXIT:
                        continuer = false;
                        break;
                    case AvailableCommand.STATION:
                        if (splitCommand.Length > 1)
                        {
                            GetStations(splitCommand[1]);
                        }
                        else
                        {
                            Console.WriteLine("Mauvais nombre d'argument");
                        }
                        break;
                    case AvailableCommand.AVAILABLE_BIKES:
                        if (splitCommand.Length > 2)
                        {
                            GetAvailableBikes(splitCommand[1], splitCommand[2]);
                        }
                        else
                        {
                            Console.WriteLine("Mauvais nombre d'argument");
                        }
                        break;
                    default:
                        Console.WriteLine("Commande inconnue");
                        break;
                }

                Console.WriteLine("--------------------------------");
            }
        }

        /// <summary>
        /// Affiche les stations d'une ville
        /// </summary>
        /// <param name="city">la ville en question</param>
        private void GetStations(string city)
        {
            Station[] stationList = this.client.GetStations(city.ToUpper());

            foreach (Station station in stationList)
            {
                Console.WriteLine(station.name + " <#> Vélos disponibles : " + station.available_bikes);
            }
        }

        /// <summary>
        /// Afficher le nombre de vélos d'une station
        /// </summary>
        /// <param name="city">ville de la station</param>
        /// <param name="station">station</param>
        private void GetAvailableBikes(string city, string station)
        {
            int number = this.client.GetNumberAvailableBike(city.ToUpper(), station.ToUpper());
            Console.WriteLine(city.ToUpper() + " => " + number + " vélo(s) disponible(s)");
        }

        /// <summary>
        /// Affiche les différentes commandes disponibles
        /// </summary>
        private void PrintHelp()
        {
            foreach (AvailableCommand comm in Enum.GetValues(typeof(AvailableCommand)))
            {
                Console.WriteLine(comm.ToString() + " : " + GetEnumDescription(comm));
            }
        }


        /// <summary>
        /// Permet de récupérer la description d'un objet AailableCommand
        /// </summary>
        /// <param name="value">un objet AvailableComman</param>
        /// <returns>la description de l'objet AailableCommand</returns>
        private string GetEnumDescription(AvailableCommand value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
