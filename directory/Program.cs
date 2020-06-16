/*
Program: HTML/Markdown document creater
Purpose: Cretes a html or markdown document using abstract factory, singletons
Coder: Sonia Friesen, 0813682
Date: Due June 7th, 2020
*/
using DocumentFactory;
using DocumentFactory.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Director
{
    class Program
    {
        //gllobal variables
        private static IDocumentFactory factory;
        private static IDocument document;
        static void Main(string[] args)
        {
            string[] commands;
            var list = File.ReadAllText("CreateDocumentScript.txt");
            commands = list.Split('#');

            foreach (var command in commands)
            {
                var strippedCommand = Regex.Replace(command, @"\t|\n|\r", "");
                var commandList = strippedCommand.Split(':');
                switch (commandList[0])
                {
                    case "Document":
                        // Your document creation code goes here
                        string[] fileName = commandList[1].Split(';');
                        if (fileName[0] == "Markdown")
                        {
                            //fileNameArray[1] == fileName
                            factory = MarkdownFactory.CreateInstance();
                            document = factory.CreateDocument(fileName[1]);
                            Console.WriteLine(fileName[1]);
                        }
                        else if (fileName[0] == "Html")
                        {
                            factory = HTMLFactory.CreateInstance();
                            document = factory.CreateDocument(fileName[1]);
                            Console.WriteLine(fileName[1]);
                        }
                        break;
                    case "Element":
                        // Your element creation code goes here
                        document.AddElement(factory.CreateElement(commandList[1], commandList[2]));
                        break;
                    case "Run":
                        // Your document running code goes here
                        document.RunDocument();
                        Console.WriteLine("Running Document");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Thanks for using...done");
            System.Environment.Exit(0);
        }
    }
}
