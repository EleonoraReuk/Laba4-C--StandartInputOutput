using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
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


    public void SaveBinary(string path)
    {
        using FileStream fs = new FileStream(path, FileMode.Create);
#pragma warning disable SYSLIB0011
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, this);
#pragma warning restore SYSLIB0011
    }

    public static TextFile LoadBinary(string path)
    {
        using FileStream fs = new FileStream (path, FileMode.Open);
#pragma warning disable SYSLIB0011
        BinaryFormatter formatter = new BinaryFormatter();
        return (TextFile)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011
    }
}

