using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace PokemonAzureUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pokemon Azure Updater";

            Console.WriteLine("Starting the download...");

            WebClient client = new WebClient();
            client.DownloadFile("https://github.com/PokemonAzure/PokemonAzure/blob/master/Builds/281019a.zip?raw=true","game.zip");

            Console.WriteLine("Download complete!");
            Console.WriteLine("Starting exctraction...");

            ZipFile.ExtractToDirectory(@"./version.zip", @"./game");

            Console.WriteLine("Extraction Complete!");
            Console.WriteLine("Cleaning up...");

            File.Delete(@"./version.zip");

            Console.WriteLine("Done! Press any key to exit.");

            Console.ReadKey();
        }
    }
}
