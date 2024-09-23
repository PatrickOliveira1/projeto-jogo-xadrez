using Tabuleiro;

namespace Xadrez
{
    internal class Dama : Piece
    {

        public Dama()
        {

        }
        public Dama(Color cor, Tabletop tab) : base(cor, tab)
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

            // oeste
            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row, pos.Column - 1);
            }
            // leste
            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row, pos.Column + 1);
            }
            // norte
            pos.DefineValues(Position.Row - 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column);
            }
            // sul
            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column);
            }
            // noroeste
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column - 1);
            }
            // nordeste
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column + 1);
            }
            // sudeste
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column + 1);
            }
            // sudoeste
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column - 1);
            }

            return mat;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
