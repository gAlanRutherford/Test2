using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberSequence.Concrete;
using NumberSequence;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberSequence = new NumberSequenceCounter(new Output());
            numberSequence.WriteSequence();
            Console.ReadLine();
        }
    }
}
