using System;

public class TextFile
{
    public string FileName { get; set; }
    public string Content { get; set; }
    public TextFile() { }
    public TextFile(string fileName, string content)
    {
        FileName = fileName; 
        Content = content;
    }
}