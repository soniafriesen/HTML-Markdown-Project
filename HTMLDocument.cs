/*
Program: HTML/Markdown document creater
Purpose: Class the creats the document using other classes
Coder: Sonia Friesen, 0813682
Date: Due June 7th, 2020
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Classes
{
    public class HTMLDocument : IDocument
    {
        string file;
        List<IElement> elements = new List<IElement>();
        public HTMLDocument(string filename)
        {
            file = filename;            
        }
        /*
        Method: AddElement()
        Purpose: To add an interface element to the List of elements for the document
        Parameters: An IElement object
        Returns:nothing
        */
        public void AddElement(IElement e)
        {
            elements.Add(e);
        }
        /*
        Method: GetFilename()
        Purpose: to get the file name
        Parameters: none
        Returns: string with the filename
        */
        public string GetFilename()
        {
            return this.file;
        }
        /*
        Method: RunDocument()
        Purpose: Craetes the document in a .html file type
        Parameters: none
        Returns: nothing
        */
        public void RunDocument()
        {
            string HTMLPage = "";

            string heading = "<!doctype html><html><head></head><body>";

            string htmlPage = "";
            foreach (IElement element in elements)
            {

                string elementLine = element.toString();
                htmlPage += elementLine;

            }
            string ending = "</body></html>";
            HTMLPage = heading + htmlPage + ending;
            string name = this.file;
            using (File.Create(name)) { };
            using (var writer = new StreamWriter(name, true))
            {
                writer.WriteLine(HTMLPage);
            };
           System.Diagnostics.Process.Start("chrome.exe", $"{Directory.GetCurrentDirectory()}\\{this.file}");
            //System.Diagnostics.Process.Start("chrome.exe", "index.html"); //opens it in chrome browser
        }
    }
}
