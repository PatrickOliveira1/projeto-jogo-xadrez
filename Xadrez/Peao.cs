using Tabuleiro;

namespace Xadrez
{
    internal class Peao : Piece
    {
        private ChessMatch Match;

        public Peao()
        {

        }
        public Peao(Color cor, Tabletop tab, ChessMatch match) : base(cor, tab)
        {
            Match = match;
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

                // #jogadaespecial EnPassant
                if(Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Tab.ValidPosition(left) && ExistEnemy(left) && Tab.Piece(left) == Match.VulnerableEnPassant) 
                    {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Tab.ValidPosition(right) && ExistEnemy(right) && Tab.Piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Row - 1, right.Column] = true;
                    }
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

                // #jogadaespecial EnPassant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Tab.ValidPosition(left) && ExistEnemy(left) && Tab.Piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Tab.ValidPosition(right) && ExistEnemy(right) && Tab.Piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }
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
