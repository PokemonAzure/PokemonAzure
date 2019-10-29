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
        static string GamePath;

        // This code is shit, but it works, so don't touch it
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory);

            if(directory.Name != "Pokemon Azure")
                GamePath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            else
                GamePath = directory.FullName;

            directory = new DirectoryInfo(GamePath);

            if(directory.Name != "Pokemon Azure" && File.Exists(directory.FullName + "\\Pokemon Azure.exe"))
            {
                Console.WriteLine("Pokemon Azure Folder was not found...\nPress any key to exit");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            Console.Title = "Pokemon Azure Updater";

            #if(!DEBUG)
            Console.WriteLine("Starting the download...");

            WebClient client = new WebClient();
            byte[] raw = client.DownloadData("https://raw.githubusercontent.com/PokemonAzure/PokemonAzure/master/version.txt");
            string webVersion = Encoding.UTF8.GetString(raw);
            client.DownloadFile("https://github.com/PokemonAzure/PokemonAzure/blob/master/Builds/" + webVersion + ".zip?raw=true", GamePath + "\\Updater\\game.zip");

            Console.WriteLine("Download complete.");
            Console.WriteLine("Removing the old version (no worry, your saves are safe! hopefully...)");

            if (Directory.Exists(GamePath))
                DeleteDirectory(GamePath);

            Console.WriteLine("Removed old version.");
            Console.WriteLine("Starting exctraction...");

            ZipFile.ExtractToDirectory(GamePath + "/Updater/game.zip", GamePath);

            Console.WriteLine("Extraction Complete.");
            Console.WriteLine("Cleaning up...");

            File.Delete(GamePath + "/Updater/game.zip");

            Console.WriteLine("Done! Press any key to exit.");

            Console.ReadKey();
            #endif
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
