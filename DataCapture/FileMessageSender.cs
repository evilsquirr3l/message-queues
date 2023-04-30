using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace DataCapture;

public class FileMessageSender
{
    private const string QueueName = "sample-queue";
    private const string QueueUrl = $"http://localhost:4566/000000000000/{QueueName}";
    
    public static async Task SendMessageAsync(string fileName)
    {
        var sqsClient = new AmazonSQSClient("000000000000", "test", "test",
            new AmazonSQSConfig()
        {
            ServiceURL = QueueUrl,
            RegionEndpoint = RegionEndpoint.USEast1
        });
        
        try
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = QueueUrl,
                MessageBody = fileName
            };

            var response = await sqsClient.SendMessageAsync(sendMessageRequest);

            Console.WriteLine($"Sent message with ID: {response.MessageId}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error message:'{e.Message}' when sending a message");
            throw;
        }
    }
}