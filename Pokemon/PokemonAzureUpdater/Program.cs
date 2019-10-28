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
        static string GamePath = "C:\\Users\\Gerbuiker\\Desktop\\Pokemon Azure";

        static void Main(string[] args)
        {
            GamePath = Directory.GetParent(Environment.CurrentDirectory).ToString();

            Console.Title = "Pokemon Azure Updater";

            Console.WriteLine("Starting the download...");

            WebClient client = new WebClient();
            client.DownloadFile("https://github.com/PokemonAzure/PokemonAzure/blob/master/Builds/281019a.zip?raw=true", "game.zip");

            Console.WriteLine("Download complete.");
            Console.WriteLine("Removing the old version (no worry, your saves are safe! hopefully...)");

            if (Directory.Exists(GamePath))
                DeleteDirectory(GamePath);

            Console.WriteLine("Removed old version.");
            Console.WriteLine("Starting exctraction...");

            ZipFile.ExtractToDirectory(@"./game.zip", GamePath);

            Console.WriteLine("Extraction Complete.");
            Console.WriteLine("Cleaning up...");

            File.Delete(@"./game.zip");

            Console.WriteLine("Done! Press any key to exit.");

            Console.ReadKey();
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                if(dir != GamePath + "\\Updater")
                    DeleteDirectory(dir);
            }

            if (target_dir != GamePath)
                Directory.Delete(target_dir, false);
        }
    }
}
