using ChuaDeThiThu.Shared;

namespace ChuaDeThiThu.API.Services.IServices
{
    public interface IFileService
    {
        Task<UploadedFile> UploadFile(IFormFile file);
    }
}
