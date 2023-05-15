using ReverseTicTacToeLogic;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace ReverseTicTacToeLogic
{
    class GameLogicManager
    {
        private readonly Competitor r_FirstCompetitor;
        private readonly Competitor r_SecondCompetitor;
        private Competitor m_CurrCompetitor;
        private readonly eGameType r_GameType;
        private readonly Board r_Board;
        private Random rand;

        public GameLogicManager(eGameType i_GameType, int i_BoardSize)
        {
            r_FirstCompetitor = new Competitor(eCellSymbol.X);
            r_SecondCompetitor = new Competitor(eCellSymbol.O);
            m_CurrCompetitor = r_FirstCompetitor;
            r_GameType = i_GameType;
            r_Board = new Board(i_BoardSize);
            rand = new Random();
        }

        public Competitor Competitor1
        {
            get
            {
                return r_FirstCompetitor;
            }
        }

        public Competitor Competitor2
        {
            get
            {
                return r_SecondCompetitor;
            }
        }

        public Competitor CurrCompetitor
        {
            get
            {
                return m_CurrCompetitor;
            }
        }

        public eGameType GameType
        {
            get
            {
                return r_GameType;
            }
        }

        public Board Board
        {
            get
            {
                return r_Board;
            }
        }

        public void InitGame()
        {
            r_Board.InitBoard();
            m_CurrCompetitor = r_FirstCompetitor;  
        }

        public static bool isValidBoardSize(int i_BoardSize)
        {
            return (i_BoardSize >= 3 && i_BoardSize <= 9);
        }

        public eGameResult EvaluateGameResult(out bool o_IsGameRoundEnd)
        {
            o_IsGameRoundEnd = true;
            eGameResult gameResult;
            

            if (r_Board.IsPlayerLoseTheGame(r_FirstCompetitor.Symbol))
            {
                gameResult = eGameResult.SecondCompetitorWin;
                r_SecondCompetitor.Victories++; 
            }
            else if (r_Board.IsPlayerLoseTheGame(r_SecondCompetitor.Symbol))
            {
                gameResult = eGameResult.FirstCompetitorWin;
                r_FirstCompetitor.Victories++;                
            }
            else if (r_Board.IsBoardFullyOccupied())
            {
                gameResult = eGameResult.Draw;
            }
            else
            {
                gameResult = eGameResult.Ongoing;
                o_IsGameRoundEnd = false;   
            }

            return gameResult;
        }

        public void NextTurn()
        {
            if (m_CurrCompetitor == r_FirstCompetitor)
            {
                m_CurrCompetitor = r_SecondCompetitor;
            }
            else
            {
                m_CurrCompetitor = r_FirstCompetitor;
            }
        }
        public void MakeRandomMove()
        {
            List<int> emptyCells = r_Board.EmptyCells;
            int countOfEmptyCells = emptyCells.Count;
            int randomPlace = emptyCells[rand.Next(countOfEmptyCells)];
            int row = randomPlace / r_Board.Size;
            int col = randomPlace % r_Board.Size;

            Thread.Sleep(500);
            r_Board.InsertSymbolToBoardCell(eCellSymbol.O, row, col);
        }
    }
}

