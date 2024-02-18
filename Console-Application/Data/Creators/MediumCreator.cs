using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Data.Creators
{
    internal class MediumCreator : IBoardCreator
    {
        private readonly int _seed;

        #region Constructors
        public MediumCreator(int seed = 0)
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
                    { 0, 0, 4,   7, 1, 0,   0, 0, 0 },
                    { 0, 7, 2,   8, 0, 6,   5, 0, 0 },
                    { 0, 0, 0,   0, 0, 5,   0, 0, 7 },

                    { 0, 1, 0,   6, 9, 0,   2, 0, 0 },
                    { 3, 9, 0,   0, 5, 0,   0, 0, 0 },
                    { 0, 0, 0,   0, 0, 0,   0, 8, 5 },

                    { 0, 0, 1,   2, 3, 0,   8, 0, 4 },
                    { 0, 0, 3,   5, 0, 4,   0, 0, 2 },
                    { 2, 4, 0,   9, 0, 0,   0, 0, 0 }
                };
            }

            return result;
        }
        #endregion
    }
}
