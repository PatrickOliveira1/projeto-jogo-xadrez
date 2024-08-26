using Tabuleiro;

namespace Xadrez
{
    internal class Torre : Piece
    {

        public Torre()
        {

        }
        public Torre(Color cor, Tabletop tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
