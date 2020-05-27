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

        [StepArgumentTransformation]
        public FolderResponseDto ToFolderResponseDto(Table table)
        {
            var result = new FolderResponseDto();
            result.metadata = table.CreateInstance<FolderMetadata>();
            return result;
        }

        [StepArgumentTransformation]
        public Base ToBase(Table table)
        {
            return table.CreateInstance<Base>();
        }
    }
}
