using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week06.Abstractions
{
    public abstract class Toy : Label
    {

        public Toy()
        {
            AutoSize = false;
            Width = 50;
            Height = 50;
            Paint += Toy_Paint;
        }

        public virtual void MoveToy()
        {
            Left += 1;
        }

        protected abstract void DrawImage(Graphics grap);

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

    }
}
