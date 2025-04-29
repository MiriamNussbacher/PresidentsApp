using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Incriment : IIncriment
    {
        int number = 0;
        public void addOne()
        {
            number++;
        }
    }
}
