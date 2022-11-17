using Mintazh2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mintazh2
{
    public partial class Form1 : Form
    {
        List<Product> _product = new List<Product>();
        string Read(string r)
        {
            using (var sr = new StreamReader(r, Encoding.Default))
            {
                var xml = sr.ReadToEnd();
                return xml;
            }
        }
        void FillProduct()
        {
            var xml = new XmlDocument();
            xml.LoadXml(Read("Menu.xml"));
            foreach (XmlElement element in xml.DocumentElement)
            {
                var name = element.SelectSingleNode("name").InnerText;
                var description = element.SelectSingleNode("description").InnerText;
                var calories = element.SelectSingleNode("calories").InnerText;
                var type = element.SelectSingleNode("type").InnerText;
                if (type=="food")
                {
                    Food f = new Food();
                    f.MyProperty2 = name;
                    f.Description = description;
                    f.MyProperty = Convert.ToInt32(calories);
                    _product.Add(f);
                }
                if (type =="drink")
                {
                    Drink d = new Drink();
                    d.MyProperty2 = name;
                    d.MyProperty = Convert.ToInt32(calories);
                    _product.Add(d);
                }
            }
        }
        void DisplayProduct()
        {
            int top = 0;
            var sorted = from x in _product orderby x.MyProperty2 select x;
            foreach (var item in _product)
            {
                item.Left = 0;
                item.Top = top;
                Controls.Add(item);
                top += item.Height;
            }
        }
        public Form1()
        {
            InitializeComponent();
            FillProduct();
            AutoScroll = true;
            DisplayProduct();
        }
    }
}
