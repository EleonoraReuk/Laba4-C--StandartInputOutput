using System.Collections.Generic;
using System.IO;
using System.Security.Principal;

public class FileIndexer
{
    public Dictionary<string, List<string>> BuildIndex(string directory, List<string>keywords)
    {
        Dictionary<string, List<string>> index = new();
        foreach(string keyword in keywords)
        {
            index[keyword] = new List<string>();

            foreach (string file in Directory.GetFiles(directory, "*.txt", SearchOption.AllDirectories))
            {
                string text = File.ReadAllText(file);
                if (text.Contains(keyword))
                {
                    index[keyword].Add(file);
                }
            }
        }
        return index;
    }
}