using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mintazh2.Class
{
    public class Food : Product
    {
        public string Description { get; set; }
        protected override void Display()
        {
            if (MyProperty<=750)
            {
                BackColor = Color.LightGreen;
            }
            else if (MyProperty>=751 && MyProperty<=1000)
            {
                BackColor = Color.LightYellow;
            }
            else if (MyProperty>=1001)
            {
                BackColor = Color.Salmon;
            }
        }
        public Food()
        {
            MouseClick += Food_MouseClick;
        }

        private void Food_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MessageBox.Show(MyProperty2 + Environment.NewLine + Description);
        }
    }
}
