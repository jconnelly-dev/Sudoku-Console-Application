using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Data.Creators
{
    internal class EasyCreator : IBoardCreator
    {
        private readonly int _seed;

        #region Constructors
        public EasyCreator(int seed = 0)
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
                    { 0, 7, 9,   8, 0, 2,   0, 6, 3 },
                    { 6, 0, 0,   9, 0, 0,   0, 1, 0 },
                    { 8, 0, 3,   0, 7, 0,   0, 0, 2 },

                    { 0, 9, 0,   0, 0, 0,   3, 7, 1 },
                    { 0, 6, 8,   7, 0, 0,   0, 9, 0 },
                    { 0, 3, 1,   0, 2, 0,   5, 8, 0 },

                    { 2, 8, 6,   5, 0, 0,   1, 3, 0 },
                    { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                    { 9, 0, 4,   3, 0, 0,   8, 2, 7 }
                };
            }

            return result;
        }
        #endregion
    }
}
