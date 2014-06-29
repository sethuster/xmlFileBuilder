using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLFileBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating some dummy elements...");
            DummyElement[] elements = new DummyElement[3];
            elements[0] = new DummyElement("Dummy Element 1", "appname/somelevel/Blank[1]/somebutton", 123, true, 3.14);
            elements[1] = new DummyElement("Dummy Element 2", "appname/somelevel/Blank[2]/another level/sometextbox", 231, false, 20546.25);
            elements[2] = new DummyElement("Dummy Element 3", "appname/somelevel/Blank[3]/somebutton", 321, true, 3.1415926535897932);
            Console.WriteLine("Attempting to write XML file from elements to C:\\");
           
            using (XmlWriter writer = XmlWriter.Create("dummyElements.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Elements");

                foreach (DummyElement dummyElement in elements)
                {
                    writer.WriteStartElement("element");

                    writer.WriteElementString("Name", dummyElement.Name);
                    writer.WriteElementString("Path", dummyElement.xPath);
                    writer.WriteElementString("ID", dummyElement.ID.ToString());
                    writer.WriteElementString("Valid", dummyElement.Valid.ToString());
                    writer.WriteElementString("decimal", dummyElement.BigNum.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("File written to disk.");
            Console.WriteLine("Reading file from disk");

            using (XmlReader reader = XmlReader.Create("dummyElements.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "element":
                                Console.WriteLine("start <element> element");
                                break;
                            case "Name":
                                if(reader.Read())
                                    Console.WriteLine("Element name" + reader.Value.Trim());
                                break;
                            case "Path":
                                if(reader.Read())
                                    Console.WriteLine("xPath: " + reader.Value.Trim());
                                break;
                        }
                    }
                }
            }

            Console.WriteLine("Does that look right to you?");
            Console.ReadLine();
        }
    }
}
