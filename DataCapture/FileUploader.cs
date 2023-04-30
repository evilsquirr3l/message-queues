using Amazon.S3;
using Amazon.S3.Transfer;

namespace DataCapture;

public class FileUploader
{
    private const string BucketName = "sample-bucket";
    private const string ServiceUrl = "http://localhost:4566";

    public static async Task UploadFileToS3Async(string filePath)
    {
        using var s3Client = new AmazonS3Client(new AmazonS3Config
        {
            ServiceURL = ServiceUrl,
            ForcePathStyle = true,
        });

        try
        {
            var fileTransferUtility = new TransferUtility(s3Client);
            
            await fileTransferUtility.UploadAsync(filePath, BucketName);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error message:'{e.Message}' when writing an object");
        }
    }
}
