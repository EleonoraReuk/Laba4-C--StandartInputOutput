using System;
using System.IO;
using System.Xml.Serialization;

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

    public void SaveXml(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
        using FileStream fs = new FileStream(path, FileMode.Create);
        serializer.Serialize(fs, this);
    }
    public static TextFile LoadXml(string path)
    {
        XmlSerializer serializer = new XmlSerializer (typeof(TextFile));
        using FileStream fs = new FileStream(path, FileMode.Open);
        return (TextFile)serializer.Deserialize(fs);
    }
}

