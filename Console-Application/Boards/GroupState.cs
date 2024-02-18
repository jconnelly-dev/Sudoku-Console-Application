using SudokuApplication.Boards.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Boards
{
    internal class GroupState
    {
        public int RowGroupId { get; set; }
        public int ColumnGroupId { get; set; }
        public bool[] Elements { get; set; }

        public GroupState(int rowGroupId, int colGroupId)
        {
            RowGroupId = rowGroupId;
            ColumnGroupId = colGroupId;
            Elements = new bool[ClassicSudoku.GROUP_AREA];
            Array.Fill(Elements, false);
        }
    }
}
