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
        public int Size
        {
            get { return r_Size; }
        }

        public eCellSign[,] Board
        {
            get { return r_Board; }
        }
        public List<int> EmptyCells
        {
            get { return m_EmptyCells; }
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
            initEmptyCells();
        }
        private void initEmptyCells()
        {
            m_EmptyCells = new List<int>();
            for (int i = 0; i < r_Size * r_Size; i++)
            {
                m_EmptyCells.Add(i);
            }
        }
        public void InsertSignToBoardCell(eCellSign i_Sign, int i_Row, int i_Col)
        {
            r_Board[i_Row, i_Col] = i_Sign;
            m_EmptyCells.Remove(i_Row * r_Size + i_Col);
        }
        public bool IsValidRowOrCol(int i_UserSelection)
        {
            return (i_UserSelection > 0 && i_UserSelection <= r_Size);
        }
        public bool IsBoardFullyOccupied()
        {
            return m_EmptyCells.Count == 0;
        } 
        public bool IsEmptyCell(int i_Row, int i_Col)
        {
            return r_Board[i_Row, i_Col] == eCellSign.Blank;
        }
        private bool IsAnyRowFullOfSameSign(eCellSign i_Sign)
        {
            for (int i = 0; i < r_Size; i++)
            {
                for(int j = 0; j < r_Size; j++)
                {
                    if (r_Board[i,j] == i_Sign && j == r_Size - 1)
                    {
                       return true;
                    }
                    else if(r_Board[i, j] != i_Sign)
                    {
                        break;
                    }
                }
            }
            return false;
        }
        private bool IsAnyColFullOfSameSign(eCellSign i_Sign)
        {
            for (int j = 0; j < r_Size; j++)
                {
                for (int i = 0; i < r_Size; i++)
                {
                    if (r_Board[i, j] == i_Sign && i == r_Size - 1)
                    {
                        return true;
                    }
                    else if (r_Board[i, j] != i_Sign)
                    {
                        break;
                    }
                }
            }
            return false;
        }
        private bool IsAnyDiagonalFullOfSameSign(eCellSign i_Sign)
        {
            bool firstDiagonal = true;
            bool secondDiagonal = true;

            for (int i = 0; i < r_Size; i++)
            {
                if(r_Board[i, i] != i_Sign)
                {
                    firstDiagonal = false;
                    break;
                }
            }

            int j = r_Size - 1;
            for (int i = 0; i < r_Size; i++)
            {
                if (r_Board[i, j] != i_Sign)
                {
                    firstDiagonal = false;
                    break;
                }
                j--;
            }

            return firstDiagonal || secondDiagonal;
        }
        public bool IsPlayerLoseTheGame(eCellSign i_Sign)
        {
            return (IsAnyRowFullOfSameSign(i_Sign) || IsAnyColFullOfSameSign(i_Sign) || IsAnyDiagonalFullOfSameSign(i_Sign));
        }
    }
}
