
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

        public Piece piece(int row, int column)
        {
            return Pieces[row, column];
        }
    }
}
