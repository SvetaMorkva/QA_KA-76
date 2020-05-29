using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestDropboxApi.DataModels;

namespace Dropbox.Api.Tests
{
    [Binding]
    public class StepTransformations
    {
        [StepArgumentTransformation]
        public UploadFileDto ToUploadFileDto(Table table)
        {
            return table.CreateInstance<UploadFileDto>();
        }

        [StepArgumentTransformation]
        public FileResponseDto ToFileResponseDto(Table table)
        {
            return table.CreateInstance<FileResponseDto>();
        }
    }
}
