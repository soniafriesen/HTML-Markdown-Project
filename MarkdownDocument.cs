/*
Program: HTML/Markdown document creater
Purpose: Cretes a markdown document using other classes
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
    public class MarkdownDocument : IDocument
    {
        string file;
        List<IElement> elements = new List<IElement>();
        public MarkdownDocument(string filename)
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
        Purpose: Craetes the document in a .md file type
        Parameters: none
        Returns: nothing
        */
        void IDocument.RunDocument()
        {
            string finalDoc = "";
            foreach (IElement element in elements)
            {
                string line = element.toString();
                finalDoc += line;
            }
            string name = this.file;
            using (File.Create(name)) { };
            using (var writer = new StreamWriter(name, true))
            {
                writer.WriteLine(finalDoc);
            }
            System.Diagnostics.Process.Start("chrome.exe", $"{Directory.GetCurrentDirectory()}\\{this.file}");
            //System.Diagnostics.Process.Start("chrome.exe", "index.md");//opens it in chrome browser
        }
    }
}
