namespace ImagesAPI.Services.Abstractions
{
    public interface IImagesService
    {
        public Task UploadImage(IFormFile image);
    }
}
