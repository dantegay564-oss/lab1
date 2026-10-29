using System;
using System.IO;
using System.Xml.Serialization;

public class XmlExporter
{
    public static void Save(Text text, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Text));

        using (FileStream stream = File.Create(fileName))
        {
            serializer.Serialize(stream, text);
        }
    }
}