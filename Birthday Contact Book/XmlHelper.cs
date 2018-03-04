using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Birthday_Contact_Book
{
    public class XmlHelper
    {
        public static SaveFile Load (string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SaveFile));
            TextReader reader = new StreamReader(fileName);
            //decode xml to save file
            SaveFile obj = (SaveFile)serializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
        //<t> is like a list, but object another level of abstraction
        public static void Save<T>(T obj, string fileName)
        {
            //now we are writing the data out
            TextWriter writer = new StreamWriter(fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }
}
