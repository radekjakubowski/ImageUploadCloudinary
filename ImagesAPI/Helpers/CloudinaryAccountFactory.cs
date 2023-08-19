using CloudinaryDotNet;
using ImagesAPI.Config;
using ImagesAPI.Helpers.Abstractions;
using Microsoft.Extensions.Options;

namespace ImagesAPI.Helpers
{
    public class CloudinaryAccountFactory : ICloudinaryAccountFactory
    {
        private readonly CloudinaryConfig _cloudinaryConfig;

        public CloudinaryAccountFactory(IOptions<CloudinaryConfig> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig.Value;
        }

        public Account CreateCloudinaryAccount()
        {
            return new Account(
                    _cloudinaryConfig.CloudName,
                    _cloudinaryConfig.Key,
                    _cloudinaryConfig.Secret
                );
        }
    }
}
