using Tabuleiro;

namespace Xadrez
{
    internal class Peao : Piece
    {

        public Peao()
        {

        }
        public Peao(Color cor, Tabletop tab) : base(cor, tab)
        {

        }

        private bool ExistEnemy(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Tab.Piece(pos) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Tab.Row, Tab.Column];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Row - 1, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 2, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos) && QtMoviments == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 2, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos) && QtMoviments == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
