using CloudinaryDotNet;

namespace ImagesAPI.Helpers.Abstractions
{
    public interface ICloudinaryAccountFactory
    {
        Account CreateCloudinaryAccount();
    }
}
