using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.State
{
    public class EditState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new EditState();
            }
            return instance;
        }

        public override void Draw(ObjectShape obj)
        {
            obj.RenderOnEditingView();
        }

        public override void Deselect(ObjectShape obj)
        {
            obj.ChangeState(StaticState.GetInstance());
        }
    }
}
