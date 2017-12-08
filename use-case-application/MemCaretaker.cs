using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MemCaretaker
    {
        List<MemMemento> savedObject = new List<MemMemento>();

        public void addMemento(MemMemento m)
        {
            savedObject.Add(m);
        }

        public MemMemento getMemento (int index)
        {
            return savedObject[index];
        }
    }
}
