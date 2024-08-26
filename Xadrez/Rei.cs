using Tabuleiro;

namespace Xadrez
{
    internal class Rei : Piece
    {
        
        public Rei()
        {

        }
        public Rei(Color cor, Tabletop tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
