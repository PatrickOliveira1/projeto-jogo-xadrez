
namespace Tabuleiro
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMoviments { get; protected set; }
        public Tabletop Tab { get; protected set; }

        public Piece()
        {

        }

        public Piece(Color color, Tabletop tab)
        {
            Position = null;
            Color = color;
            Tab = tab;
            QtMoviments = 0;
        }

        public void IncrementQtMoviments()
        {
            QtMoviments++;
        }

        public abstract bool[,] PossibleMoviments();
    }
}
