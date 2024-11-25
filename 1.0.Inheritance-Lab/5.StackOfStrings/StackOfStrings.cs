using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Stack<string> AddRange(IEnumerable<string> range)
        {
            foreach (string element in range)
            {
                Push(element);
            }

            return this;
        }
    }
}
