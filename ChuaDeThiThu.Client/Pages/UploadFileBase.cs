using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace ChuaDeThiThu.Client.Pages
{
    public class UploadFileBase : ComponentBase
    {
        public IBrowserFile file { get; set; }
        public string uploadMessage { get; set; } = string.Empty;

        [Inject]
        public HttpClient httpClient { get; set; }

        public async Task HandleFileChange(InputFileChangeEventArgs e)
        {
            file = e.File;
            uploadMessage = string.Empty;
        }

        public async Task UploadFile()
        {
            var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(file.OpenReadStream(file.Size));

            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            content.Add(streamContent, "file", file.Name);

            var response = await httpClient.PostAsync("api/file/upload", content);

            if (response.IsSuccessStatusCode)
            {
                uploadMessage = "Successfully.";
            }
            else
            {
                uploadMessage = "Failed.";
            }
        }
    }
}
