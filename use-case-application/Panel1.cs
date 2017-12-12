using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCaseApp
{
    class Panel1 : Panel
    {
        public Panel1()
        {
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}
