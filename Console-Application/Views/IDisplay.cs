using SudokuApplication.Algorithms;
using SudokuApplication.Boards;
using SudokuApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Views
{
    internal interface IDisplay
    {
        public void DisplaySetup(IBoardCreator creator, out ISudoku? sudoku);
        public void DisplaySolve(ISolver solver, ref ISudoku? sudoku);
        public void DisplaySudoku(ISudoku? sudoku, string message);
        public void DisplayStart();
        public void DisplayEnd();
        public void DisplayWait();
    }
}
