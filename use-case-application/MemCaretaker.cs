using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    class MemCaretaker
    {
        private Stack<MemMemento> UndoStack = new Stack<MemMemento>();
        private Stack<MemMemento> RedoStack = new Stack<MemMemento>();

        public MemMemento getUndoMemento()
        {
            if (UndoStack.Count >= 2)
            {
                RedoStack.Push(UndoStack.Pop());
                return UndoStack.Peek();
            }
            else
                return null;
        }
        public MemMemento getRedoMemento()
        {
            if (RedoStack.Count != 0)
            {
                MemMemento m = RedoStack.Pop();
                UndoStack.Push(m);
                return m;
            }
            else
                return null;
        }
        public void InsertMementoForUndoRedo(MemMemento memento)
        {
            if (memento != null)
            {
                UndoStack.Push(memento);
                RedoStack.Clear();
            }
        }
        public bool IsUndoPossible()
        {
            if (UndoStack.Count >= 2)
            {
                return true;
            }
            else
                return false;

        }
        public bool IsRedoPossible()
        {
            if (RedoStack.Count != 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
