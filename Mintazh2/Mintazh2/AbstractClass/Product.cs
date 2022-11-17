using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mintazh2.Class
{
    public abstract class Product : Button
    {
        private int Calories;

        public int MyProperty
        {
            get { return Calories; }
            set { Calories = value; Display(); }
        }
        private string Title;

        public string MyProperty2
        {
            get { return Title; }
            set { Title = value; Text = Title; }
        }
        protected abstract void Display();
        public Product()
        {
            Width = 150;
            Height = 50;
        }
    }
}
