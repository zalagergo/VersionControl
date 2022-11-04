using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week06.Abstractions;

namespace week06.Entities
{
    public class BallFactory:IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
