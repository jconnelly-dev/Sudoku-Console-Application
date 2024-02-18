using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Boards
{
    internal class ElementState<E> where E : struct
    {
        public E Value { get; }
        public int Frequency { get; set; }

        public ElementState(E value, int freqency = 0)
        {
            Value = value;
            Frequency = freqency;
        }
    }
}
