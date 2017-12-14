using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    class MemMemento
    {
        private List<ObjectShape> obj;

        public MemMemento(List<ObjectShape> thisObj)
        {
            obj = thisObj;
        }

        public List<ObjectShape> getSavedObject()
        {            
            return obj;
        }
    }
}
