using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace MainProcessing;

public class MessageReader
{
    private const string QueueUrl = $"http://localhost:4566/000000000000/sample-queue";
    private const int MaxNumberOfMessages = 10;

    public static async Task<IEnumerable<string>> ReceiveMessageAsync()
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
            var messages = new List<string>();

            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = QueueUrl,
                MaxNumberOfMessages = MaxNumberOfMessages
            };

            var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest);

            foreach (var message in response.Messages)
            {
                var fileMessage = message.Body;
                messages.Add(fileMessage);

                var deleteMessageRequest = new DeleteMessageRequest
                {
                    QueueUrl = QueueUrl,
                    ReceiptHandle = message.ReceiptHandle
                };

                await sqsClient.DeleteMessageAsync(deleteMessageRequest);
            }
            
            return messages;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error message:'{e.Message}' when reading a message");
            throw;
        }
    }
}
