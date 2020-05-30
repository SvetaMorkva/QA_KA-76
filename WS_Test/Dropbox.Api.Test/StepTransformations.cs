using Dropbox.Api.Test.Infrastructure.Commands;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dropbox.Api.Tests
{
    [Binding]
    public class StepTransformations
    {
        // DropboxAPI

        [StepArgumentTransformation]
        public CreateFolderRequest ToCreateFolderRequest(Table table)
        {
            return table.CreateInstance<CreateFolderRequest>();
        }

        [StepArgumentTransformation]
        public GetMetadataRequest ToGetMetadataRequest(Table table)
        {
            return table.CreateInstance<GetMetadataRequest>();
        }

        [StepArgumentTransformation]
        public ListFolderRequest ToListFolderRequest(Table table)
        {
            return table.CreateInstance<ListFolderRequest>();
        }

        [StepArgumentTransformation]
        public DeleteRequest TODeleteRequest(Table table)
        {
            return table.CreateInstance<DeleteRequest>();
        }

        // Content.DropboxAPI

        [StepArgumentTransformation]
        public UploadRequest ToUploadRequest(Table table)
        {
            return table.CreateInstance<UploadRequest>();
        }

        [StepArgumentTransformation]
        public DownloadRequest ToDownloadRequest(Table table)
        {
            return table.CreateInstance<DownloadRequest>();
        }
    }
}
