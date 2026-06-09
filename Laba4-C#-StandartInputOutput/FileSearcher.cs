using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileSearcher
{
    public List<string> Search(string directory, string keyword)
    {
        return Directory
            .GetFiles(directory, "*.txt", SearchOption.AllDirectories)
            .Where(file => File.ReadAllText(file).Contains(keyword))
            .ToList();
    }
}