using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class emptyException : Exception
    { 
        public emptyException(string Message) : base(Message)
        {

        }
    }
}
