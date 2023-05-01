using MainProcessing;

var filePath = "output.txt";
var messages = await MessageReader.ReceiveMessageAsync();

foreach (var message in messages)
{
    Console.WriteLine($"Url: {message}");
    FileWriter.WriteStringToFile(filePath, message);
}
