using ChuaDeThiThu.API.Data;
using ChuaDeThiThu.API.Services.IServices;
using ChuaDeThiThu.Shared;

namespace ChuaDeThiThu.API.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment environment;

        public FileService(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {
            this.dbContext = dbContext;
            this.environment = environment;
        }
        public async Task<UploadedFile> UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            // c1
            //var fileStream = new FileStream(filePath, FileMode.Create);
            //try
            //{
            //    await file.CopyToAsync(fileStream);
            //}
            //finally
            //{
            //    fileStream.Close();
            //    fileStream.Dispose();
            //}

            // Luu file vao thu muc wwwroot/uploads
            var filePath = Path.Combine(this.environment.ContentRootPath, "wwwroot", "uploads", file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Doc content cua file
            byte[] fileContent;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            // Luu thong tin file vao database
            var uploadedFile = new UploadedFile
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileContent = fileContent
            };

            this.dbContext.UploadedFiles.Add(uploadedFile);
            await this.dbContext.SaveChangesAsync();

            return uploadedFile;
        }
    }
}
