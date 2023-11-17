using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class BlobManager
    {
        private string connectionString;
        private string inputContainerName;
        private string inputFilePath;

        private string outputContainerName;
        private string outputFilePath;

        private BlobServiceClient blobServiceClient;
        public BlobManager(string connectionString, string inputContainerName, string inputFilePath, string outputContainerName, string outputFilePath)
        {
            this.connectionString = connectionString;
            this.inputContainerName = inputContainerName;
            this.inputFilePath = inputFilePath;

            this.outputContainerName = outputContainerName;
            this.outputFilePath = outputFilePath;

            this.blobServiceClient = new BlobServiceClient(this.connectionString);

        }


        public void UploadToBlob()
        {
            // connect our storage account 
            // BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString);

            //get a blob container
            var containerClient = blobServiceClient.GetBlobContainerClient(this.inputContainerName);

            bool isExist = containerClient.Exists();
            if (!isExist)
            {
                containerClient = blobServiceClient.CreateBlobContainer(this.inputContainerName);
            }

            // access files on PC that will be uploaded to blob
            var filesToUpload = Directory.GetFiles(inputFilePath);
            Console.WriteLine($"Uploding files...\nLocation: {inputFilePath}\n--------------------------");

            foreach (var file in filesToUpload)
            {
                using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(file)))
                {

                        containerClient.UploadBlob(Path.GetFileName(file), stream);
                }
                Console.WriteLine(file + "----> [UPLOADED]");
            }


        }

        public void DownloadFromBlob()
        {
            //BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString);

            var containerClient = blobServiceClient.GetBlobContainerClient(this.outputContainerName);



            var filesToDownload = containerClient.GetBlobs();
            Console.WriteLine($"Downloading files...\n--------------------------");
            foreach (var file in filesToDownload)
            {
                Console.WriteLine(outputFilePath + file.Name + " ---> [DOWNLOADED]");
                BlobClient blobClient = containerClient.GetBlobClient(file.Name);
                string fullPath = String.Concat(this.outputFilePath, "/", file.Name);
                blobClient.DownloadTo(fullPath);

            }

        }
    }
}
