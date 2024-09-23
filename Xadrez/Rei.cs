using Tabuleiro;

namespace Xadrez
{
    internal class Rei : Piece
    {

        private ChessMatch Match;

        public Rei(Color cor, Tabletop tab, ChessMatch match) : base(cor, tab)
        {
            Match = match;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }

        private bool TestTorreForRoque(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p != null && p is Torre && p.Color == Color && p.QtMoviments == 0;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Tab.Row, Tab.Column];

            Position pos = new Position(0, 0);

            // norte
            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // nordeste
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // leste
            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // sudeste
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // sul
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // sudoeste
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // oeste
            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // noroeste
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // #jogadaespecial roque
            if (QtMoviments == 0 && !Match.Check)
            {
                // #jogadaespecial roque pequeno
                Position posT1 = new Position(Position.Row, Position.Column + 3);
                if (TestTorreForRoque(posT1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Position posT2 = new Position(Position.Row, Position.Column - 4);
                if (TestTorreForRoque(posT2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null && Tab.Piece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
