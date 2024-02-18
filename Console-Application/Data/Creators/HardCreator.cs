using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Data.Creators
{
    internal class HardCreator : IBoardCreator
    {
        private readonly int _seed;

        #region Constructors
        public HardCreator(int seed = 0)
        {
            _seed = seed;
        }
        #endregion

        #region Board Creator Interface
        public int[,] CreateBoard()
        {
            int[,] result = new int[0, 0];
            if (_seed == 0)
            {
                result = new int[,]
                {
                    { 0, 0, 0,   8, 4, 0,   0, 0, 5 },
                    { 0, 0, 0,   1, 0, 0,   0, 3, 6 },
                    { 0, 5, 7,   0, 2, 6,   0, 1, 0 },

                    { 0, 0, 0,   0, 0, 0,   3, 0, 0 },
                    { 0, 6, 0,   7, 1, 0,   0, 0, 0 },
                    { 8, 1, 0,   0, 0, 5,   0, 0, 0 },

                    { 1, 0, 0,   5, 6, 0,   7, 0, 0 },
                    { 0, 0, 0,   2, 7, 0,   0, 0, 9 },
                    { 0, 9, 4,   0, 0, 0,   0, 0, 0 }
                };
            }

            return result;
        }
        #endregion
    }
}
