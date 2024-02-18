using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Boards
{
    internal interface ISudoku
    {
        public int[,] GetContents();
        public int GetEmptyElement();

        /*
         * Each element within the array represents a single allowable value for a sudoku element.
         *  The element contains info about it's value and the number of times that value appears within the entire sudoku.
         *  The list is sorted by values w/the highest frequency to lowest frequency.
         */
        public List<ElementState<int>> GetValueFrequency();
    }
}
