/*
Program: HTML/Markdown document creater
Purpose: Cretes a the elements for a markdown document
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
    public class MarkdownImage : IElement
    {
        string element = "";
        public MarkdownImage(string props)
        {
            element = props;
        }       
        /*
        Method: toString()
        Purpose: Craetes the markdown formate
        Parameters: none
        Returns: string
        */
        public string toString()
        {
            string FianlElement;
            string[] imageElement = element.Split(';');
            FianlElement = "![" + imageElement[1] + "](" + imageElement[0] + " \"" + imageElement[2] + "\")\n";
            return FianlElement;
        }
    }
    public class MarkdownHeader : IElement
    {
        string element = "";
        public MarkdownHeader(string props)
        {
            element = props;
        }       
        /*
        Method: toString()
        Purpose: Craetes the markdown formate
        Parameters: none
        Returns: string
        */
        public string toString()
        {
            string finalElement;
            string hash = "";
            string[] headerElement = element.Split(';');
            for (var i = 0; i < Int32.Parse(headerElement[0]); i++)
            {
                hash += "#";
            }
            finalElement = hash + " " + headerElement[1] + "\n";
            return finalElement;
        }
    }
    public class MarkdownList : IElement
    {
        string element = "";
        public MarkdownList(string props)
        {
            element = props;
        }       
        /*
        Method: toString()
        Purpose: Craetes the markdown formate
        Parameters: none
        Returns: string
        */
        public string toString()
        {
            string finalElement = "";
            string temp = "";
            string[] listElements = element.Split(';');
            if (listElements[0].Equals("Ordered"))
            {
                for (var i = 1; i < listElements.Length; i++)
                {
                    temp = i + ". ";
                    finalElement += temp + listElements[i] + "\n";
                }
            }
            else if (listElements[0].Equals("Unordered"))
            {
                for (var i = 1; i < listElements.Length; i++)
                {
                    temp = "* ";
                    finalElement += temp + listElements[i] + "\n";
                }
            }
            return finalElement;
        }
    }
    public class MarkdownTable : IElement
    {
        string element = "";
        public MarkdownTable(string props)
        {
            element = props;
        }       
        /*
       Method: toString()
       Purpose: Craetes the markdown formate
       Parameters: none
       Returns: string
       */
        public string toString()
        {
            string finalElement = "";
            string temp = "";
            string[] lines = element.Split(';');
            string[] parts = lines[0].Split('$');
            for (var i = 1; i < parts.Length; i++)
            {
                temp = "| ";
                finalElement += temp + parts[i] + " ";
            }
            finalElement += " | \n";

            for (var i = 1; i < parts.Length; i++)
            {
                temp = "| ";
                finalElement += temp + "--- ";
            }
            finalElement += " | \n";

            string[] rows1 = lines[1].Split('$');
            for (var i = 1; i < rows1.Length; i++)
            {
                temp = "| ";
                finalElement += temp + rows1[i] + " ";
            }
            finalElement += " | \n";

            string[] rows2 = lines[1].Split('$');
            for (var i = 1; i < rows2.Length; i++)
            {
                temp = "| ";
                finalElement += temp + rows2[i] + " ";
            }
            finalElement += " | \n";

            string[] rows3 = lines[1].Split('$');
            for (var i = 1; i < rows1.Length; i++)
            {
                temp = "| ";
                finalElement += temp + rows3[i] + " ";
            }
            finalElement += " | \n";
            return finalElement;
        }
    }
}
