using System;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public static async Task<String> UploadToAzure()
        {
            StorageSharedKeyCredential cred = new StorageSharedKeyCredential("myblobdata1", "njLNgGSHN2b85NGxlTD3EdMofNkPRlqru9yTdBAr5P0sHWaKqWsiLg8hpBicG7tv1oAoFYtxuuF22r+dv69OVw==");
            Uri uri = new Uri("https://myblobdata1.blob.core.windows.net/mycontainer/sheep.jpg");
            BlobClient client = new BlobClient(uri, cred);
            FileStream fs = File.OpenRead("sheep.jpg");
            await client.UploadAsync(fs);
            return "Uploaded Successfully";
        }
        static void Main(string[] args)
        {
            UploadToAzure().Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
