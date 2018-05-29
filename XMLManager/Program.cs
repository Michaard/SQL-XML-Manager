using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFilename = "37.xml";
            XmlParser parser = new XmlParser();
            Root xmlRoot = parser.Parse(xmlFilename);

            XmlGenerator generator = new XmlGenerator();
            generator.Generate("generated.xml", xmlRoot);

            DataBase db = new DataBase();

            //db.ClearXmlDatabase();
            //db.InsertIntoXmlDatabase(xmlRoot);

            Root loadedRoot = db.LoadDataFromXmlDatabase();

            generator.Generate("xml_from_db.xml", loadedRoot);
        }
    }
}
