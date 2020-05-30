using Aropbox.Api.Tests.Infrastructure.DataModels;
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

        [StepArgumentTransformation]
        public CreateFolderDto ToCreateFolderDto(Table table)
        {
            return table.CreateInstance<CreateFolderDto>();
        }
    }
}
