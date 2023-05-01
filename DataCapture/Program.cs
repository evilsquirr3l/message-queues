using DataCapture;

var files = FileFinder.GetFilesInFolder("pdf", "test");

foreach (var file in files)
{
    var fileUrl = await FileUploader.UploadFileToS3Async(file);

    await FileMessageSender.SendMessageAsync(fileUrl);

    Console.WriteLine($"File is uploaded to s3, link: {fileUrl}");
}
