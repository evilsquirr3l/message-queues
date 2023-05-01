namespace MainProcessing;

public class FileWriter
{
    public static void WriteStringToFile(string filePath, string content)
    {
        try
        {
            File.AppendAllText(filePath, content + Environment.NewLine);
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while writing to the file: {e.Message}");
        }
    }
}