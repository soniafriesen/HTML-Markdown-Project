using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public interface IElement
    {
        string toString(); //had to add because the toString wasn't being recosgnized by the class
    }
}
