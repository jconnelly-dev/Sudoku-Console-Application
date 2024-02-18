using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Data
{
    internal interface IBoardCreator
    {
        public int[,] CreateBoard();
    }
}
