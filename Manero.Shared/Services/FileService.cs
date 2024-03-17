using Manero.Shared.Interfaces;
using System.Diagnostics;

namespace Manero.Shared.Services;

public class FileService : IFileService
{
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if(File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine("FileService - ReadContentFromFile:: " + ex.Message); }
        return null!;
    }



    public bool SaveContentToFile(string filePath, string content)
    {
        try
        {
            // Skapar filen automatiskt om den inte existerar
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine("FileService - SaveContentToFile:: " + ex.Message); }
        return false;
    }
}
