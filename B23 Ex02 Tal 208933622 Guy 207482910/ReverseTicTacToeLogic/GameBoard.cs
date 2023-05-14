using ReverseTicTacToeLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseTicTacToeLogic
{
    public class GameBoard
    {
        private readonly int r_Size;
        private readonly eCellSign[,] r_Board;
        private List<int> m_EmptyCells;

        public GameBoard(int i_BoardLen)
        {
            r_Board = new eCellSign[i_BoardLen, i_BoardLen];
            r_Size = i_BoardLen;
        }
        public void InitBoard()
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    r_Board[i, j] = eCellSign.Blank;
                }
            }
        }
    }
}
