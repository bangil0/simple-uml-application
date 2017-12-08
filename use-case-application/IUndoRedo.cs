using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    interface IUndoRedo
    {
        void Undo(int level);
        void Redo(int level);
        void SetStateForUndoRedo();
    }
}
