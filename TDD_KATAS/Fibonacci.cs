using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class Fibonacci
    {
        public int F(int position)
        {
            if (position == 0)
            {
                return 0;
            }
            else if(position == 1)
            {
                return 1;
            }
            else
            {
                return F(position - 1) + F(position - 2);
            }
        }
    }
}
