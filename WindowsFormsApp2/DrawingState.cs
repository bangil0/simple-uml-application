using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public abstract class DrawingState
    {
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public abstract void Draw(ObjectShape obj);

        public virtual void Deselect(ObjectShape obj)
        {
            //default implementation, no state transition
        }

        public virtual void Select(ObjectShape obj)
        {
            //default implementation, no state transition
        }
    }
}
