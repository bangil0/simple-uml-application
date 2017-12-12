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
        MemCaretaker _Caretaker = new MemCaretaker();
        MemOriginator _MementoOriginator = null;
        public event EventHandler EnableDisableUndoRedoFeature;

        public UndoRedo(ICanvas container)
        {
            _MementoOriginator = new MemOriginator(container);

        }
        public void Undo(int level)
        {
            Debug.WriteLine("Memento " + _Caretaker.IsUndoPossible());
            MemMemento memento = null;
            for (int i = 1; i <= level; i++)
            {
                memento = _Caretaker.getUndoMemento();
            }
            if (memento != null)
            {
                _MementoOriginator.setMemento(memento);

            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void Redo(int level)
        {
            MemMemento memento = null;
            for (int i = 1; i <= level; i++)
            {
                memento = _Caretaker.getRedoMemento();
            }
            if (memento != null)
            {
                _MementoOriginator.setMemento(memento);

            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void SetStateForUndoRedo()
        {
            MemMemento memento = _MementoOriginator.getMemento();
            _Caretaker.InsertMementoForUndoRedo(memento);
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public bool IsUndoPossible()
        {
            return _Caretaker.IsUndoPossible();
        }
        public bool IsRedoPossible()
        {
            return _Caretaker.IsRedoPossible();
        }

        public void getUndoLevel()
        {
            Debug.WriteLine("Undo Level " + _Caretaker.getUndoLevel());
        }
    }
}
