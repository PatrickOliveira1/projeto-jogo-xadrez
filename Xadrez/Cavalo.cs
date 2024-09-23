using Tabuleiro;

namespace Xadrez
{
    internal class Cavalo : Piece
    {

        public Cavalo()
        {

        }
        public Cavalo(Color cor, Tabletop tab) : base(cor, tab)
        {

        }

        private bool CanMove(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Tab.Row, Tab.Column];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Row - 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
