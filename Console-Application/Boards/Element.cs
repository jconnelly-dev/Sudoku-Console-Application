using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Boards
{
    internal class Element<E> where E : struct
    {
        public E Value { get; }
        public int RowId { get; }
        public int ColumnId { get; }

        public Element(E value, int rowIdx, int colIdx)
        {
            Value = value;
            RowId = rowIdx;
            ColumnId = colIdx;
        }
    }
}
