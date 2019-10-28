using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAzureUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pokemon Azure Updater";

            Console.WriteLine("Starting the update...");



            Console.ReadKey();
        }

        public static void downloadFile(string sourceURL, string destinationPath)
        {
            long fileSize = 0;
            int bufferSize = 1024;
            bufferSize *= 1000;
            long existLen = 0;

            System.IO.FileStream saveFileStream;
            if (System.IO.File.Exists(destinationPath))
            {
                System.IO.FileInfo destinationFileInfo = new System.IO.FileInfo(destinationPath);
                existLen = destinationFileInfo.Length;
            }

            if (existLen > 0)
                saveFileStream = new System.IO.FileStream(destinationPath,
                                                          System.IO.FileMode.Append,
                                                          System.IO.FileAccess.Write,
                                                          System.IO.FileShare.ReadWrite);
            else
                saveFileStream = new System.IO.FileStream(destinationPath,
                                                          System.IO.FileMode.Create,
                                                          System.IO.FileAccess.Write,
                                                          System.IO.FileShare.ReadWrite);

            System.Net.HttpWebRequest httpReq;
            System.Net.HttpWebResponse httpRes;
            httpReq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sourceURL);
            httpReq.AddRange((int)existLen);
            System.IO.Stream resStream;
            httpRes = (System.Net.HttpWebResponse)httpReq.GetResponse();
            resStream = httpRes.GetResponseStream();

            fileSize = httpRes.ContentLength;

            int byteSize;
            byte[] downBuffer = new byte[bufferSize];

            while ((byteSize = resStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
            {
                saveFileStream.Write(downBuffer, 0, byteSize);
            }
        }
    }
}
