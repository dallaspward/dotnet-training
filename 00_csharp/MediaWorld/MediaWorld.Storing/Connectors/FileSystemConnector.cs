using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Storing.Connectors
{
  public class FileSystemConnector
  {
    private const string _path = @"storage.xml";

    public List<AMedia> ReadXml(string path = _path)
    {
      var xml = new XmlSerializer(typeof(List<AMedia>)); //this is our translator
      var reader = new StreamReader(path); //location of the file
      return xml.Deserialize(reader) as List<AMedia>; //give the file to the translator, translate, then cast as List<AMedia>
    }

    public void WriteXml(List<AMedia> data, string path = _path)
    {
      var xml = new XmlSerializer(typeof(List<AMedia>));
      var writer = new StreamWriter(path);
      xml.Serialize(writer, data);
    }
  }
}