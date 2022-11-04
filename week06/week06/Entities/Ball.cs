﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week06.Abstractions;

namespace week06.Entities
{
    public class Ball : Toy
    {
        protected override void DrawImage(Graphics grap)
        {
            grap.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }
    }
}
