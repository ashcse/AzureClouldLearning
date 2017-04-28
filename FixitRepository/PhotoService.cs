using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace FixitRepository
{
    public class PhotoService
    {
        public async Task<string> UploadFotoAsync(HttpPostedFileBase photo)
        {
            CloudStorageAccount account =
                CloudStorageAccount.Parse("BlobEndpoint=https://kharestorageaccount.blob.core.windows.net/;QueueEndpoint=https://kharestorageaccount.queue.core.windows.net/;TableEndpoint=https://kharestorageaccount.table.core.windows.net/;FileEndpoint=https://kharestorageaccount.file.core.windows.net/;AccountName=kharestorageaccount;AccountKey=vk5H+JBhm2UvVS5RVs1gi8dld1KNSnOpIGTQCtCrNazlgEuXdDfFR6hb8XmovbjKMdO/wsyj8UiCbHq3D+KSoQ==");

            CloudBlobContainer container = account.CreateCloudBlobClient().GetContainerReference("images");

            string imageName = string.Format("photo-{0}-{1}", Guid.NewGuid(), Path.GetExtension(photo.FileName));

            CloudBlockBlob block = container.GetBlockBlobReference(imageName);
            block.Properties.ContentType = photo.ContentType;
            await block.UploadFromStreamAsync(photo.InputStream);
            return block.Uri.ToString();
        }
    }
}
