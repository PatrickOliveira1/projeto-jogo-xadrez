
namespace Tabuleiro
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMoviments { get; protected set; }
        public Tabletop Tab { get; protected set; }

        public Piece()
        {

        }

        public Piece(Position position, Color color, Tabletop tab)
        {
            Position = position;
            Color = color;
            Tab = tab;
            QtMoviments = 0;
        }
    }
}
