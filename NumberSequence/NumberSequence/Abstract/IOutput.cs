using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequence.Abstract
{
    public interface IOutput
    {
        void WriteLine(int line);
        void WriteLine(int line, string message);
    }
}
