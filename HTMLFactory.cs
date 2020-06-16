/*
Program: HTML/Markdown document creater
Purpose: Cretes a singleton instance of a html object
Coder: Sonia Friesen, 0813682
Date: Due June 7th, 2020
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Classes
{
    public class HTMLFactory : IDocumentFactory
    {
        private static HTMLFactory instance;       
        private HTMLFactory()
        {
            Console.WriteLine("Creating  HTML Factory (As singleton)");
        }    
        //creates a singleton instance
        public static HTMLFactory CreateInstance()
        {
            if (instance == null)
            {
                instance = new HTMLFactory();
            }
            return instance;
        }
        public IDocument CreateDocument(string fileName)
        {
            return new HTMLDocument(fileName);
        }

        public IElement CreateElement(string elementType, string props)
        {
            switch (elementType)
            {
                case "Header":
                    return new HTMLHeader(props);
                case "Image":
                    return new HTMLImage(props);
                case "List":
                    return new HTMLList(props);
                case "Table":
                    return new HTMLTable(props);
                default:
                    return null;
            }

        }

        public static IDocumentFactory Get()
        {
            throw new NotImplementedException();
        }
    }
}
