using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberSequence.Abstract;

namespace NumberSequence.Concrete
{
    public class Output : IOutput
    {
        public void WriteLine(int line)
        {
            WriteLine("{0}", line);
        }
        public void WriteLine(int line, string message)
        {
            WriteLine("{0}: {1}", line, message);
        }
        private void WriteLine(string format, params object[] arguments)
        {
            Console.WriteLine(format, arguments);
        }
    }
}
