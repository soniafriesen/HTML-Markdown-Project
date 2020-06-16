/*
Program: HTML/Markdown document creater
Purpose: Class the creats the elements for a document
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
    public class HTMLImage : IElement
    {
        string element = "";
        public HTMLImage(string props)
        {
            element = props;
        } 
        /*
       Method: toString()
       Purpose: Craetes the html formate
       Parameters: none
       Returns: string
       */
        public string toString()
        {
            string finalElement;
            string[] imageElement = element.Split(';');
            finalElement = "<img src=\"" + imageElement[0] + "\" alt=\"" + imageElement[1] + "\" title=\"" + imageElement[2] + "\"><br>";
            return finalElement;
        }
    }
    public class HTMLHeader : IElement
    {
        string element = "";
        public HTMLHeader(string props)
        {
            element = props;
        }      
        /*
       Method: toString()
       Purpose: Craetes the html formate
       Parameters: none
       Returns: string
       */
        public string toString()
        {
            string finalElement;
            string[] headerElement = element.Split(';');
            finalElement = "<h" + headerElement[0] + "> " + headerElement[1] + "</h" + headerElement[0] + ">";
            //Console.WriteLine(finalElement);
            return finalElement;
        }
    }
    public class HTMLList : IElement
    {
        string element = "";
        public HTMLList(string props)
        {
            element = props;
        }
        /*
       Method: toString()
       Purpose: Craetes the html formate
       Parameters: none
       Returns: string
       */
        public string toString()
        {
            string finalElement = "";
            string[] listElements = element.Split(';');
            if (listElements[0].Equals("Ordered"))
            {
                finalElement = "<ol> <li>" + listElements[1] + "</li> <li > " + listElements[2] + " </li > <li>" + listElements[3] + "</li> </ol>";
            }
            else if (listElements[0].Equals("Unordered"))
            {
                finalElement = "<ul> <li>" + listElements[1] + "</li> <li > " + listElements[2] + " </li > <li>" + listElements[3] + "</li> </ul>";
            }            
            return finalElement;
        }
    }
    public class HTMLTable : IElement
    {
        string elementProps = "";
        public HTMLTable(string props)
        {
            elementProps = props;
        }
        /*
       Method: toString()
       Purpose: Craetes the html formate
       Parameters: none
       Returns: string
       */
        public string toString()
        {
            string finalElement;
            string[] lines = elementProps.Split(';');
            string[] parts = lines[0].Split('$');
            string[] rows = lines[1].Split('$');
            string[] rows2 = lines[2].Split('$');
            string[] rows3 = lines[3].Split('$');
            finalElement = "<table> <thead> <tr> <th> " + parts[1] + "</th> <th> " + parts[2] + "</th> <th> " + parts[3] + "</th> </tr> </thead> <tbody> <tr> <td>"
                    + rows[1] + "</td> <td> " + rows[2] + "</td> <td> " + rows[3] + "</td> </tr> <tr> <td> " + rows2[1] + "</td> <td> " + rows2[2] + "</td> <td> " + rows[3]
                    + "</td> </tr> <tr> <td> " + rows3[1] + "</td> <td> " + rows3[2] + "</td> <td> " + rows3[3] + "</td> </tr> </tbody> </table>";
            return finalElement;
        }
    }
}
