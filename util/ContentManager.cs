using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DoesCoreAPI.util
{
    public class ContentManager
    {

        private XmlDocument _doc = new XmlDocument();
        private const string _mainDocument = "site.xml"; 

        public ContentManager()
        {
          
            var filePath = Directory.GetCurrentDirectory() + "/content/" + _mainDocument;

            System.Console.WriteLine("about to parse..." + filePath);
            var xmlString = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            using (XmlReader reader = XmlReader.Create(xmlString))
            {
                reader.MoveToContent();
                reader.Read();
                _doc.Load(reader);
            }
        }

        public string ListResult()
        {
            var jsonString = File.ReadAllText(Directory.GetCurrentDirectory() + "\\content\\" + "phones.json");
            return jsonString.ToString();
        }

        public string DetailResult(string id)
        {
            var jsonString = File.ReadAllText(Directory.GetCurrentDirectory() + "\\content\\phones\\" + id + ".json");
            return jsonString.ToString();
        }

        public IEnumerable<string> Result(string segment)
        {
            XmlNodeList xnList = _doc.GetElementsByTagName("link");
            List<string> result = new List<string>();
            foreach(var node in xnList)
            {
                result.Add(((System.Xml.XmlNode)node).FirstChild.InnerText);
            }

            return result;
        }

        public XmlDocument nodeResult()
        {
            //XmlNodeList xnList = _doc.GetElementsByTagName(segment);
            
            return _doc;

        }

    }
}
