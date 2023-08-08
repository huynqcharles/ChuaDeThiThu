using ChuaDeThiThu.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuaDeThiThu.API.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var uploadedFile = await this.fileService.UploadFile(file);

            if (uploadedFile == null)
            {
                return BadRequest("Upload failed.");
            }
            else
            {
                return Ok(uploadedFile);
            }
        }
    }
}
