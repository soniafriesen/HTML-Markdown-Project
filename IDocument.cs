using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public interface IDocument
    {
        void AddElement(IElement e);
       void RunDocument();
        string GetFilename(); //return this.file (html or markdown)    
        
    }
}
