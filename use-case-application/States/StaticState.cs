﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.States
{
    public class StaticState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new StaticState();
            }
            return instance;
        }

        public override void Draw(ObjectShape obj)
        {
            obj.RenderOnStaticView();
        }

        public override void Select(ObjectShape obj)
        {
            obj.ChangeState(EditState.GetInstance());
        }
    }
}
