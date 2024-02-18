using SudokuApplication.Boards;
using SudokuApplication.Boards.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SudokuApplication.Algorithms.Solvers
{
    internal class SimpleSolver : ISolver
    {
        public SimpleSolver() { }

        #region Solver Interface
        public int[,] Solve(ISudoku? sudoku)
        {
            if (sudoku == null)
            {
                throw new ArgumentException("Error: the sudoku provided to solve is null");
            }

            int[,] board = sudoku.GetContents();
            if (board.Length <= 0)
            {
                throw new ArgumentException("Error: the sudoku provided to solve is empty");
            }
            if (board.Rank != ClassicSudoku.NUM_AXES)
            {
                throw new ArgumentException("Error: the sudoku provided to solve has invalid axes");
            }
            if (board.GetLength(0) != ClassicSudoku.BASE_LENGTH)
            {
                throw new ArgumentException("Error: the sudoku provided to solve has an invalid row length");
            }
            if (board.GetLength(1) != ClassicSudoku.BASE_LENGTH)
            {
                throw new ArgumentException("Error: the sudoku provided to solve has an invalid column length");
            }

            List<ElementState<int>> valueCounts = sudoku.GetValueFrequency();
            if (valueCounts == null || valueCounts.Count != ClassicSudoku.BASE_LENGTH)
            {
                throw new ArgumentException("Error: unable to determine sudoku value counts");
            }

            // TODO... jconnelly... this is valid debug code, just currently disabled.
            //StringBuilder debugger = new StringBuilder();
            //valueCounts.ForEach(element => debugger.AppendLine($"value={element.Value}, count={element.Frequency}"));
            //throw new ArgumentException($"joey debug ->{Environment.NewLine}{debugger.ToString()}");

            int[,] result = new int[ClassicSudoku.BASE_LENGTH, ClassicSudoku.BASE_LENGTH];



            //GroupState[] groupStates = new GroupState[ClassicSudoku.NUM_GROUPS];
            //groupStates[verticalGroupId + horizontalGroupId] = new GroupState(verticalGroupId, horizontalGroupId);





            // HORIZONTAL_GROUP_CHECK: Find if mf is in group1, then group2, then group3
            //  - if it was in 3: done looking horizontally, now look vertically:
            //  - if it was in 2:
            //      - HORIZONTAL_ELEMENT_CHECK:
            //       - if 1 empty position: we found a value for an empty element!!! fill the element w/mf and BREAK!!!
            //       - if 2 empty positions: done looking horizontally, now look vertically:
            //       - if 3 empty positions:done looking horizontally, now look vertically:
            //          - VERTICAL_GROUP_CHECK: Find if mf is in group2, then group3 (we know it's not in group1 because of HORIZONTAL_GROUP_CHECK)
            //           - if it was in 2:
            //           - if it was in 1:
            //           - if it was in 0: 
            //  - if it was in 1:
            //       - boom
            // VERTICAL_GROUP_CHECK: Find if mf is in group1, then group2, then group3
            //  - if it was in 3: done looking vertically, continue to the next vertical group down 1
            //  - if it was in 2:
            //  - if it was in 1: 







            int mf = valueCounts.First().Value; // most frequent value

            for (int verticalGroupId = 1, rowIdx = 0; verticalGroupId <= ClassicSudoku.GROUP_LENGTH; verticalGroupId++, rowIdx += ClassicSudoku.GROUP_LENGTH)
            {
                bool[] horizontalGroups = new bool[ClassicSudoku.GROUP_LENGTH];
                for (int horizontalGroupId = 1, colIdx = 0; horizontalGroupId <= ClassicSudoku.GROUP_LENGTH; horizontalGroupId++, colIdx += ClassicSudoku.GROUP_LENGTH)
                {
                    

                    if ((board[rowIdx, colIdx] == mf     || board[rowIdx, colIdx + 1] == mf     || board[rowIdx, colIdx + 2] == mf) ||
                        (board[rowIdx + 1, colIdx] == mf || board[rowIdx + 1, colIdx + 1] == mf || board[rowIdx + 1, colIdx + 2] == mf) ||
                        (board[rowIdx + 2, colIdx] == mf || board[rowIdx + 2, colIdx + 1] == mf || board[rowIdx + 2, colIdx + 2] == mf))
                    {
                        isInGroup = true;
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
