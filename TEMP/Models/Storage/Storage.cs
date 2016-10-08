using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Storage
{
    public class Storage
    {
        public object CloudConfigurationManager { get; private set; }

        public String uploadfile(String customerID, String contractname )
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(customerID);
            container.CreateIfNotExists();
            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(contractname);

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@"C:\Users\Nguyen Nhat\Downloads\Documents\draftsla_us.pdf"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
           
            return blockBlob.Uri.ToString();


        }
    }
}