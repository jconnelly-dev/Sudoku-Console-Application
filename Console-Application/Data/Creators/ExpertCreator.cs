using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Data.Creators
{
    internal class ExpertCreator : IBoardCreator
    {
        private readonly int _seed;

        #region Constructors
        public ExpertCreator(int seed = 0)
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
                    { 0, 3, 1,   0, 0, 2,   9, 0, 8 },
                    { 0, 2, 0,   0, 0, 0,   0, 3, 0 },
                    { 0, 0, 0,   0, 8, 0,   0, 0, 5 },

                    { 9, 0, 0,   0, 0, 5,   0, 0, 7 },
                    { 0, 0, 4,   2, 0, 8,   0, 0, 0 },
                    { 0, 0, 0,   0, 7, 3,   0, 0, 0 },

                    { 0, 9, 0,   0, 1, 0,   0, 2, 0 },
                    { 0, 1, 8,   0, 0, 0,   0, 5, 0 },
                    { 0, 5, 0,   8, 0, 4,   0, 6, 9 }
                };
            }

            return result;
        }
        #endregion
    }
}
