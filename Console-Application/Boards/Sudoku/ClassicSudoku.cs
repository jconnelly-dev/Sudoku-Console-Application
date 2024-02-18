using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Boards.Sudoku
{
    internal class ClassicSudoku : ISudoku
    {
        private readonly int _empty;
        private readonly int[,] _raw;

        #region Constants
        public const int NUM_AXES = 2;      // number of dimensional axes, 1 row axis + 1 column axis = 2 axes
        public const int MIN_VALUE = 1;     // the minimum integer value of an element
        public const int MAX_VALUE = 9;     // the maximum integer value of an element
        public const int GROUP_LENGTH = 3;  // the number of elements that make up the height||width of a group
        public const int BASE_LENGTH = 9;   // the number of elements that make up the height||width of the entire sudoku
        public const int NUM_GROUPS = 9;    //

        public const int GROUP_AREA = GROUP_LENGTH * GROUP_LENGTH;  // (area=9) the number of elements in a minor box
        public const int TOTAL_AREA = BASE_LENGTH * BASE_LENGTH;    // (area=81) the number of elements in the entire sudoku
        public const int DEFAULT_EMPTY_VALUE = MIN_VALUE - 1;       // the default value assigned to empty board positions if not specified
        #endregion

        #region Constructors
        public ClassicSudoku()
        {
            _empty = DEFAULT_EMPTY_VALUE;
            _raw = new int[BASE_LENGTH, BASE_LENGTH];
            for (int row = 0; row < BASE_LENGTH; row++)
            {
                for (int column = 0; column < BASE_LENGTH; column++)
                {
                    _raw[row, column] = 0;
                }
            }
        }

        public ClassicSudoku(int[,] preBuilt, int emptyElement = DEFAULT_EMPTY_VALUE) // Overload
        {
            ValidateSudoku(preBuilt, emptyElement);

            _empty = emptyElement;
            _raw = new int[BASE_LENGTH, BASE_LENGTH];

            // Create a deep copy.
            for (int row = 0; row < BASE_LENGTH; row++)
            {
                for (int column = 0; column < BASE_LENGTH; column++)
                {
                    _raw[row, column] = preBuilt[row, column];
                }
            }
        }
        #endregion

        #region Sudoku Interface
        public int[,] GetContents()
        {
            return _raw;
        }

        public int GetEmptyElement()
        {
            return _empty;
        }

        public List<ElementState<int>> GetValueFrequency()
        {
            List<ElementState<int>> sorted = new List<ElementState<int>>(BASE_LENGTH);

            // TODO... jconnelly... keep for later:
            //Enumerable.Range(1, BASE_LENGTH).ToList().ForEach(x => result.Add(x, 0));

            if (_raw != null)
            {
                ElementState<int>[] states = Enumerable.Range(1, BASE_LENGTH)
                    .Select(i => new ElementState<int>(value: i, freqency: 0)).ToArray();

                int verticalLength = _raw.GetLength(0);
                int horizontalLength = _raw.GetLength(1);
                for (int rowIdx = 0; rowIdx < verticalLength; rowIdx++)
                {
                    for (int colIdx = 0; colIdx < horizontalLength; colIdx++)
                    {
                        int elementValue = _raw[rowIdx, colIdx];
                        if (elementValue != _empty)
                        {
                            int stateIdx = elementValue - 1; // to account for the 0-based index shift for arrays
                            states[stateIdx].Frequency++;
                        }
                    }
                }

                sorted = states.OrderByDescending(x => x.Frequency).ToList();
            }

            return sorted;
        }
        #endregion

        #region Validation
        private void ValidateSudoku(int[,] sudoku, int emptyElement)
        {
            ValidateBaseProperties(sudoku, emptyElement);

            HashSet<int>[] columnValues = Enumerable.Range(1, BASE_LENGTH).Select(i => new HashSet<int>()).ToArray();
            for (int rowIdx = 0; rowIdx < BASE_LENGTH; rowIdx++)
            {
                HashSet<int> rowValues = new HashSet<int>();
                for (int colIdx = 0; colIdx < BASE_LENGTH; colIdx++)
                {
                    int elementValue = sudoku[rowIdx, colIdx];

                    ValidateValueBounds(elementValue, rowIdx, colIdx);

                    ValidateAxisUniqueness(elementValue, rowValues, rowIdx, colIdx, axisName: "row");
                    rowValues.Add(elementValue);

                    ValidateAxisUniqueness(elementValue, columnValues[colIdx], rowIdx, colIdx, axisName: "column");
                    columnValues[colIdx].Add(elementValue);
                }
            }
        }

        private void ValidateBaseProperties(int[,] data, int emptyElement)
        {
            if (data == null)
            {
                throw new ArgumentException("Error: the sudoku provided is null");
            }
            if (data.Rank != NUM_AXES)
            {
                throw new ArgumentException($"Error: the sudoku is required to have '{NUM_AXES}' dimensional axes, 1 row axis + 1 column axis;" +
                    $"the sudoku provided has a dimension of '{data.Rank}'");
            }

            int numberRows = data.GetLength(0);
            if (numberRows != BASE_LENGTH)
            {
                throw new ArgumentException($"Error: the total number of rows in the sudoku is required to be '{BASE_LENGTH}' elements;" +
                    $"the sudoku provided has '{numberRows}' columns");
            }
            int numberColumns = data.GetLength(1);
            if (numberColumns != BASE_LENGTH)
            {
                throw new ArgumentException($"Error: the total number of columns in the sudoku is required to be '{BASE_LENGTH}' elements;" +
                    $"the sudoku provided has '{numberColumns}' columns");
            }

            if (data.Length != TOTAL_AREA)
            {
                throw new ArgumentException($"Error: the total number of elements in the sudoku is required to be '{TOTAL_AREA}';" +
                    $"the sudoku provided has '{data.Length}' elements");
            }

            if (MIN_VALUE <= emptyElement && emptyElement <= MAX_VALUE)
            {
                throw new ArgumentException($"Error: the value assigned to empty elements cannot be within the range of valid element values;" +
                    $"i.e. the empty element value is required to be less than '{MIN_VALUE}', or greater than '{MAX_VALUE}';" +
                    $"the sudoku provided has an empty element value of '{emptyElement}'");
            }
        }

        private void ValidateValueBounds(int value, int rowIdx, int colIdx)
        {
            if (rowIdx < 0 || colIdx > BASE_LENGTH)
            {
                throw new Exception("Error: the world is on fire, please evacuate quitely and in peace");
            }

            if (value != _empty)
            {
                if (value < MIN_VALUE)
                {
                    throw new ArgumentException($"Error: the minimum value for an element is '{MIN_VALUE}';" +
                        $"the sudoku provided has a value of '{value}' found on [row,col] '[{rowIdx},{colIdx}]'");
                }
                if (value > MAX_VALUE)
                {
                    throw new ArgumentException($"Error: the maximum value for an element is '{MAX_VALUE}';" +
                        $"the sudoku provided has a value of '{value}' found on [row,col] '[{rowIdx},{colIdx}]'");
                }
            }
        }

        private void ValidateAxisUniqueness(int value, HashSet<int> axisValues, int rowIdx, int colIdx, string axisName)
        {
            if (rowIdx < 0 || colIdx > BASE_LENGTH || axisValues == null || string.IsNullOrEmpty(axisName))
            {
                throw new Exception("Error: the world is on fire, please evacuate quitely and in peace");
            }

            if (value != _empty)
            {
                if (axisValues.Contains(value))
                {
                    throw new ArgumentException($"Error: no element can repeat in value within a given '{axisName}';" +
                        $"the sudoku provided has a duplicate value of '{value}' found on [row,col] '[{rowIdx},{colIdx}]'");
                }
            }
        }
        #endregion
    }
}
