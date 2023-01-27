using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task_HW_25012023
{
    public class Ex6
    {
        private readonly static Ex6 _EX6 = new Ex6();
        public static Ex6 EX6
        {
            get { return _EX6; }
        }

        public async Task<string> loop()
        {
            string result = await FetchXML();
            return result;
        }

        private Task<string> FetchXML()
        {
            string lastItem = "";
            return Task.Run(() =>
            {
                Thread.Sleep(60000);
                try
                {
                    // Fetch XML file
                    WebClient client = new WebClient(); //מוריד את הקובץ מכתובת האתר
                    string xmlString = client.DownloadString("http://www.ynet.co.il/Integration/StoryRss2.xml");

                    // Load XML string into XmlDocument
                    XmlDocument doc = new XmlDocument(); //יוצר אובייקט חדש לעבודה עם xml
                    doc.LoadXml(xmlString);// טוען מהמחרוזת ומקבל את כל הפרמטרים 

                    // Get first new item
                    XmlNodeList items = doc.GetElementsByTagName("item");
                    foreach (XmlNode item in items)
                    {
                        XmlNode titleNode = item.SelectSingleNode("title");
                        string title = titleNode.InnerText;
                        if (title != lastItem)
                        {
                            lastItem = title;
                            return title;

                        }

                    }
                }
                catch (WebException)
                {
                    Console.WriteLine("Error fetching XML file.");
                }
                return "Error fetching XML file.";

            });
        }

    }
}
