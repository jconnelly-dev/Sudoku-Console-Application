using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Data.Creators
{
    internal class CompletedCreator : IBoardCreator
    {
        private readonly int _seed;

        #region Constructors
        public CompletedCreator(int seed = 0)
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
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                    { 3, 4, 5, 6, 7, 8, 9, 1, 2 },

                    { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                    { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
                    { 6, 7, 8, 9, 1, 2, 3, 4, 5 },

                    { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                    { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
                    { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
                };
            }

            return result;
        }
        #endregion
    }
}
