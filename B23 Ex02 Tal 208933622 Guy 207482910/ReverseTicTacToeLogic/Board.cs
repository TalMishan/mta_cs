using ReverseTicTacToeLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseTicTacToeLogic
{
    public class Board
    {
        private readonly int r_Size;
        private readonly eCellSymbol[,] r_Board;
        private List<int> m_EmptyCells;

        public Board(int i_BoardSize)
        {
            r_Board = new eCellSymbol[i_BoardSize, i_BoardSize];
            r_Size = i_BoardSize;
        }

        public int Size
        {
            get { return r_Size; }
        }

        public eCellSymbol[,] GameBoard
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
                    r_Board[i, j] = eCellSymbol.Empty;
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

        public void InsertSymbolToBoardCell(eCellSymbol i_Symbol, int i_Row, int i_Col)
        {
            r_Board[i_Row, i_Col] = i_Symbol;
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
            return r_Board[i_Row, i_Col] == eCellSymbol.Empty;
        }

        private bool IsAnyRowFullOfSameSymbol(eCellSymbol i_Symbol)
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    if (r_Board[i, j] == i_Symbol && j == r_Size - 1)
                    {
                        return true;
                    }
                    else if (r_Board[i, j] != i_Symbol)
                    {
                        break;
                    }
                }
            }
            return false;
        }

        private bool IsAnyColFullOfSameSymbol(eCellSymbol i_Symbol)
        {
            for (int j = 0; j < r_Size; j++)
            {
                for (int i = 0; i < r_Size; i++)
                {
                    if (r_Board[i, j] == i_Symbol && i == r_Size - 1)
                    {
                        return true;
                    }
                    else if (r_Board[i, j] != i_Symbol)
                    {
                        break;
                    }
                }
            }
            return false;
        }

        private bool IsAnyDiagonalFullOfSameSymbol(eCellSymbol i_Symbol)
        {
            bool firstDiagonal = true;
            bool secondDiagonal = true;

            for (int i = 0; i < r_Size; i++)
            {
                if (r_Board[i, i] != i_Symbol)
                {
                    firstDiagonal = false;
                    break;
                }
            }

            int j = r_Size - 1;
            for (int i = 0; i < r_Size; i++)
            {
                if (r_Board[i, j] != i_Symbol)
                {
                    firstDiagonal = false;
                    break;
                }
                j--;
            }

            return firstDiagonal || secondDiagonal;
        }

        public bool IsPlayerLoseTheGame(eCellSymbol i_Symbol)
        {
            return (IsAnyRowFullOfSameSymbol(i_Symbol) || IsAnyColFullOfSameSymbol(i_Symbol) || IsAnyDiagonalFullOfSameSymbol(i_Symbol));
        }
    }
}
