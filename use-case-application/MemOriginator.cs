using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    class MemOriginator
    {
        private ObjectShape obj;

        public void set (ObjectShape thisObj)
        {
            this.obj = thisObj;
        }

        public MemMemento storeInMemento()
        {
            return new MemMemento(obj);
        }

        public ObjectShape restoreFromMemento(MemMemento memento)
        {
            obj = memento.getSavedObject();

            return obj;
        }
    }
}
