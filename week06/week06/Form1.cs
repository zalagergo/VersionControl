using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week06.Abstractions;
using week06.Entities;

namespace week06
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        Toy _nextToy;

        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; DisplayNext(); }
        }

        private void DisplayNext()
        {
            if (_nextToy!=null)
            {
                Controls.Remove(_nextToy);
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Top = lblNext.Top + lblNext.Height + 20;
            _nextToy.Left = lblNext.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy b = Factory.CreateNew();
            _toys.Add(b);
            mainPanel.Controls.Add(b);
            b.Left = -b.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var item in _toys)
            {
                item.MoveToy();
                if(item.Left>maxPosition)
                {
                    maxPosition = item.Left;
                }
                if (maxPosition >= 1000)
                {
                    Toy b1 = _toys[0];
                    _toys.Remove(b1);
                    mainPanel.Controls.Remove(b1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = button3.BackColor
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();
            colorPicker.Color = button3.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button.BackColor = colorPicker.Color;
            }
        }
    }
}
