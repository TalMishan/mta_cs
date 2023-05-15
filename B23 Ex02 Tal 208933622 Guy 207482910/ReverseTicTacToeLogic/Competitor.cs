namespace ReverseTicTacToeLogic
{
 class Competitor
    {
        private readonly eCellSymbol r_CompetitorSymbol;
        private int m_Victories;

        public Competitor(eCellSymbol i_Symbol)
        {     
            r_CompetitorSymbol = i_Symbol;
            m_Victories = 0;
        }
        public eCellSymbol Symbol
        {
            get
            {
                return r_CompetitorSymbol;
            }
        }
        public int Victories
        {
            get
            {
                return m_Victories;
            }
            set
            {
                m_Victories = value;
            }
        }      
    }
}