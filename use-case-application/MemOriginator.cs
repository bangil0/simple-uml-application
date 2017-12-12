using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    class MemOriginator
    {
        private ICanvas canvasState;

        public MemOriginator(ICanvas canvas)
        {
            canvasState = canvas;
        }

        public void set(ICanvas canvas)
        {
            this.canvasState = canvas;
        }

        public MemMemento getMemento()
        {
            List<ObjectShape> objectShapes = new List<ObjectShape>();

            foreach (ObjectShape obj in canvasState.getObjectShapes())
            {
                ObjectShape newObj = (ObjectShape)obj.Clone();
                objectShapes.Add(newObj);
            }

            return new MemMemento(objectShapes);
        }

        public void setMemento(MemMemento memento)
        {
            MemMemento curMem = CloneMemento(memento);
            canvasState.setObjectShapes(curMem.getSavedObject());
        }

        public MemMemento CloneMemento(MemMemento mem)
        {
            List<ObjectShape> objectShapes = new List<ObjectShape>();

            foreach (ObjectShape obj in mem.getSavedObject())
            {
                ObjectShape newObj = (ObjectShape)obj.Clone();
                objectShapes.Add(newObj);
            }

            return new MemMemento(objectShapes);
        }
    }
}
