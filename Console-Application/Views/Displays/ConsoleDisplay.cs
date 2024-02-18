using SudokuApplication.Algorithms;
using SudokuApplication.Algorithms.Solvers;
using SudokuApplication.Boards;
using SudokuApplication.Boards.Sudoku;
using SudokuApplication.Data;
using SudokuApplication.Data.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Views.Displays
{
    internal class ConsoleDisplay : IDisplay
    {
        private readonly string _appName;
        private readonly string _newBlockText;
        private readonly string _newLine;
        private readonly char _tab;

        #region Constants
        private const char _delimiter = ';';
        private const char _elementSpace = ' ';
        private const char _groupDivider = '|';
        #endregion

        #region Constructors
        public ConsoleDisplay(string applicationName, string newLine, char tab)
        {
            _newLine = newLine ?? throw new ArgumentNullException(nameof(newLine));
            _appName = applicationName ?? throw new ArgumentNullException(nameof(applicationName));
            _newBlockText = $"{_newLine}{_tab}";
            _tab = tab;
        }
        #endregion

        #region Display Interface
        public void DisplaySetup(IBoardCreator creator, out ISudoku? sudoku)
        {
            try
            {
                int[,] startingBoard = creator.CreateBoard();
                sudoku = new ClassicSudoku(startingBoard);
            }
            catch (ArgumentException argEx)
            {
                string errMsg = argEx.Message?.Replace(_delimiter.ToString(), _newBlockText) ?? string.Empty;
                Console.WriteLine($"*** Invalid Starting Board ***{_newBlockText}{errMsg}");
                sudoku = null;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message?.Replace(_delimiter.ToString(), _newBlockText) ?? string.Empty;
                Console.WriteLine($"*** Unhandled Exception ***{_newBlockText}{errMsg}");
                sudoku = null;
            }
        }

        public void DisplaySolve(ISolver solver, ref ISudoku? sudoku)
        {
            try
            {
                int[,] solution = solver.Solve(sudoku);
                sudoku = new ClassicSudoku(solution);
            }
            catch (ArgumentException argEx)
            {
                string errMsg = argEx.Message?.Replace(_delimiter.ToString(), _newBlockText) ?? string.Empty;
                Console.WriteLine($"*** Invalid Starting Board ***{_newBlockText}{errMsg}");
                sudoku = null;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message?.Replace(_delimiter.ToString(), _newBlockText) ?? string.Empty;
                Console.WriteLine($"*** Unhandled Exception ***{_newBlockText}{errMsg}");
                sudoku = null;
            }
        }

        public void DisplaySudoku(ISudoku? sudoku, string message)
        {
            if (sudoku == null)
            {
                Console.WriteLine($"*** Invalid Board ***{_newBlockText}Error: sudoku is null");
                return;
            }

            int[,] board = sudoku.GetContents();
            if (board.Length == 0)
            {
                Console.WriteLine($"*** Invalid Board ***{_newBlockText}Error: sudoku is empty");
                return;
            }

            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine($"{_newLine}{message}");
            }

            int verticalLength = board.GetLength(0);
            int horizontalLength = board.GetLength(1);
            StringBuilder vertical = new StringBuilder();
            for (int x = 0; x < verticalLength; x++)
            {
                StringBuilder horizontal = new StringBuilder();
                for (int y = 0; y < horizontalLength; y++)
                {
                    // Add horizontal formating to the left/right of the element.
                    horizontal.Append(_elementSpace);
                    if (y != 0 && y % 3 == 0)
                    {
                        horizontal.Append(_groupDivider);
                        horizontal.Append(_elementSpace);
                    }

                    // Add the element w/in the horizontal line of text.
                    horizontal.Append(board[x, y]);
                }
                string singleLine = horizontal.ToString();

                // Add vertical formatting above the first vertical element.
                if (x == 0)
                {
                    vertical.Append(_elementSpace);
                    vertical.AppendLine(new string('-', singleLine.Length + 1));
                }

                // Add the horizontal line of text as a new vertical element.
                vertical.Append(_elementSpace);
                vertical.AppendLine(singleLine);

                // Add vertical formatting below each grouping of vertical elements.
                if ((x + 1) % 3 == 0)
                {
                    vertical.Append(_elementSpace);
                    vertical.AppendLine(new string('-', singleLine.Length + 1));
                }
            }

            Console.Write(vertical.ToString());
        }

        public void DisplayStart()
        {
            Console.WriteLine($"--- START {_appName} ---");
        }

        public void DisplayEnd()
        {
            Console.WriteLine($"{_newLine}--- END {_appName} ---");
        }

        public void DisplayWait()
        {
            Console.ReadKey();
        }
        #endregion
    }
}