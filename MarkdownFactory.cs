/*
Program: HTML/Markdown document creater
Purpose: Cretes a singleton instance of markdown
Coder: Sonia Friesen, 0813682
Date: Due June 7th, 2020
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Classes
{
    public class MarkdownFactory:IDocumentFactory
    {
        private static MarkdownFactory instance;

        private MarkdownFactory()
        {
            Console.WriteLine("Creating Markdown Factory ( as Singleton)");
        }

        public static MarkdownFactory CreateInstance()
        {
            if (instance == null)
            {
                instance = new MarkdownFactory();
            }
            return instance;
        }

        public IDocument CreateDocument(string path)
        {
            return new MarkdownDocument(path);
        }

        public IElement CreateElement(string elementType, string props)
        {
            switch (elementType)
            {
                case "Header":
                    return new MarkdownHeader(props);
                case "Image":
                    return new MarkdownImage(props);
                case "List":
                    return new MarkdownList(props);
                case "Table":
                    return new MarkdownTable(props);
                default:
                    return null;

            }
        }
    }
}
