using SudokuApplication.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Algorithms
{
    internal interface ISolver
    {
        public int[,] Solve(ISudoku? sudoku);
    }
}
