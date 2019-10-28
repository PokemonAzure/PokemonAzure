using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Engine;
using System.Diagnostics;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Version check
            #if (!DEBUG)
            WebClient wc = new WebClient();
            byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/PokemonAzure/PokemonAzure/master/version.txt");

            string webVersion = Encoding.UTF8.GetString(raw);

            if (GameWindow.VERSION != webVersion)
            {
                Console.WriteLine("There is an update available. \nDo you wish to update the game?");
                Console.WriteLine("type 'update' to continue, otherwise press enter.");

                string updateCheck = Console.ReadLine();

                if(updateCheck == "y")
                {
                    Console.WriteLine("By updating the game we will close the game and open the updater\npress any key to continue");
                    Console.ReadKey();

                    Process.Start(Environment.CurrentDirectory + "/Updater/PokemonAzureUpdater.exe");
                    Environment.Exit(0);
                }
            }
            #endif

            new Game.Game();
        }
    }
}
