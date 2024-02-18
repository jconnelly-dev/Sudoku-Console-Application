using Microsoft.VisualBasic;
using SudokuApplication.Algorithms;
using SudokuApplication.Algorithms.Solvers;
using SudokuApplication.Boards;
using SudokuApplication.Boards.Sudoku;
using SudokuApplication.Data;
using SudokuApplication.Data.Creators;
using SudokuApplication.Views;
using SudokuApplication.Views.Displays;

IDisplay console = new ConsoleDisplay(nameof(SudokuApplication), Environment.NewLine, ControlChars.Tab);
console.DisplayStart();

IBoardCreator creator = new EasyCreator();
console.DisplaySetup(creator, out ISudoku? sudoku);
console.DisplaySudoku(sudoku, message: "Starting board configuration:");

ISolver simpleSolver = new SimpleSolver();
console.DisplaySolve(simpleSolver, ref sudoku);
console.DisplaySudoku(sudoku, message: "Solved board configuration:");

console.DisplayEnd();
console.DisplayWait();