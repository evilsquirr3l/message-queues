namespace DataCapture;

public class FileFinder
{
    public static List<string> GetFilesInFolder(string fileExtension, string folderName)
    {
        var folderPath = Path.Combine(Environment.CurrentDirectory, folderName);

        if (!Directory.Exists(folderPath))
        {
            throw new InvalidOperationException($"Directory not found: {folderPath}");
        }

        var files = Directory.GetFiles(folderPath, $"*.{fileExtension}").ToList();

        return files;
    }
}
