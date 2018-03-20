using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberSequence.Abstract;

namespace NumberSequence
{
    public class NumberSequenceCounter
    {
        public const string ANSIBLE = "Ansible";
        public const string AUSTRALIA = "Australia";
        public const string ANSIBLE_AUSTRALIA = "Ansible Australia";

        public const int ANSIBLE_NUMBER = 3;
        public const int AUSTRALIA_NUMBER = 5;

        public const int MIN_COUNT = 1;
        public const int MAX_COUNT = 100;

        private readonly IOutput _output;
        public NumberSequenceCounter(IOutput output)
        {
            _output = output;
        }

        public void WriteSequence()
        {
            for (int i = MIN_COUNT; i <= MAX_COUNT; i++)
            {
                if (i % ANSIBLE_NUMBER == 0 && i % 5 == 0)
                {
                    _output.WriteLine(i, ANSIBLE_AUSTRALIA);
                }
                else if (i % ANSIBLE_NUMBER == 0)
                {
                    _output.WriteLine(i, ANSIBLE);
                }
                else if (i % 5 == 0)
                {
                    _output.WriteLine(i, AUSTRALIA);
                }
                else
                {
                    _output.WriteLine(i);
                }
            }
        }
    }
}
