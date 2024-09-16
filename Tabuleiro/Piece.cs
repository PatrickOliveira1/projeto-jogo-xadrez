
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
        public void DecrementQtMoviments()
        {
            QtMoviments--;
        }

        public bool HasPossibleMoviments()
        {
            bool[,] mat = PossibleMoviments();

            for (int i = 0; i < Tab.Row; i++)
            {
                for (int j = 0; j < Tab.Column; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveFor(Position pos)
        {
            return PossibleMoviments()[pos.Row, pos.Column];
        }
        public abstract bool[,] PossibleMoviments();
    }
}
