using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImagesAPI.Config;
using ImagesAPI.Helpers;
using ImagesAPI.Helpers.Abstractions;
using ImagesAPI.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace ImagesAPI.Services
{
    public class CloudinaryImagesService : IImagesService
    {
        private readonly Cloudinary _cloudinaryClient;
        private readonly ICloudinaryAccountFactory _cloudinaryAccountFactory;

        public CloudinaryImagesService(IOptions<CloudinaryConfig> cloudinaryConfiguration, ICloudinaryAccountFactory cloudinaryAccountFactory)
        {
            _cloudinaryClient = new Cloudinary(_cloudinaryAccountFactory.CreateCloudinaryAccount());
        }

        public async Task UploadImage(IFormFile image)
        {
            var imageStream = image.OpenReadStream();
            var imageUploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.FileName, imageStream),        
            };

            var imageUploadResponse = await _cloudinaryClient.UploadAsync(imageUploadParams);

            // rest of the stuff like sending some domain event or persisting it to db
        }
    }
}
