using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    class MemMemento
    {
        private ObjectShape obj;

        public MemMemento(ObjectShape thisObj)
        {
            obj = thisObj;
        }

        public ObjectShape getSavedObject()
        {
            return obj;
        }
    }
}
