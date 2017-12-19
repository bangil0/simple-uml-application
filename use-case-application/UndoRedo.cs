using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    public class UndoRedo : IUndoRedo
    {
        MemCaretaker careTaker = new MemCaretaker();
        MemOriginator mementoOriginator = null;

        public UndoRedo(ICanvas container)
        {
            mementoOriginator = new MemOriginator(container);
        }

        public void Undo(int level)
        {
            MemMemento memento = null;

            for (int i = 1; i <= level; i++)
            {
                memento = careTaker.getUndoMemento();
            }

            if (memento != null)
            {
                mementoOriginator.setMemento(memento);
            }
        }

        public void Redo(int level)
        {
            MemMemento memento = null;

            for (int i = 1; i <= level; i++)
            {
                memento = careTaker.getRedoMemento();
            }

            if (memento != null)
            {
                mementoOriginator.setMemento(memento);

            }
        }

        public void SetStateForUndoRedo()
        {
            MemMemento memento = mementoOriginator.getMemento();
            careTaker.InsertMementoForUndoRedo(memento);
        }

        public bool IsUndoPossible()
        {
            return careTaker.IsUndoPossible();
        }

        public bool IsRedoPossible()
        {
            return careTaker.IsRedoPossible();
        }

        public void getUndoLevel()
        {
            Debug.WriteLine("Undo Level " + careTaker.getUndoLevel());
        }
    }
}
