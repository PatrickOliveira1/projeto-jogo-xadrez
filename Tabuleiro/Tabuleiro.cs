
namespace Tabuleiro
{
    internal class Tabletop
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces { get; set; }

        public Tabletop()
        {

        }

        public Tabletop(int row, int column)
        {
            Row = row;
            Column = column;
            Pieces = new Piece[row, column];
        }

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            Pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }
    }
}
