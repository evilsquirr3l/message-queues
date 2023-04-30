using DataCapture;

var files = FileFinder.GetFilesInFolder("pdf", "test");

foreach (var file in files)
{
    await FileUploader.UploadFileToS3Async(file);
    Console.WriteLine($"{file} is uploaded to S3.");
}
