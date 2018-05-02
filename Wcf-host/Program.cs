using System;
using System.ServiceModel;
using Wcf_Service;

namespace Wcf_host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(VelibService));
            host.Open();
            Console.WriteLine("Le service est bien host. Pressez une touche pour arreter le service");
            Console.ReadLine();
            host.Close();
        }
    }
}
