using Azure.Storage.Blobs;

namespace RedMango.API.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<bool> DeleteBlob(string blobName, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            return await blobClient.DeleteIfExistsAsync();
        }

        public Task<string> GetBlob(string blobName, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadBlob(string blobName, string containerName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
