using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week06.Abstractions;

namespace week06.Entities
{
    public class Car : Toy
    {
        protected override void DrawImage(Graphics grap)
        {
            Image imageFile = Image.FromFile("Images/car.png");
            grap.DrawImage(imageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}
