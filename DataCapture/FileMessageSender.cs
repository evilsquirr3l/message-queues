using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace DataCapture;

public class FileMessageSender
{
    private const string QueueUrl = $"http://localhost:4566/000000000000/sample-queue";

    public static async Task SendMessageAsync(string fileName)
    {
        using var sqsClient = new AmazonSQSClient(new AmazonSQSConfig()
        {
            ServiceURL = QueueUrl,
            RegionEndpoint = RegionEndpoint.USEast1,
            ProxyHost = "localhost",
            ProxyPort = 4566,
            UseHttp = true
        });

        try
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = QueueUrl,
                MessageBody = fileName
            };

            await sqsClient.SendMessageAsync(sendMessageRequest);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error message:'{e.Message}' when sending a message");
            throw;
        }
    }
}