using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp.State
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
            
        }

        public virtual void Select(ObjectShape obj)
        {
            
        }
    }
}
