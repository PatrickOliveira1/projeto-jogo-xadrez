
namespace Tabuleiro
{
    internal class Tabletop
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Piece[,] Pieces { get; set; }

        public Tabletop()
        {

        }

        public Tabletop(int row, int column)
        {
            Row = row;
            Column = column;
            Pieces = new Piece[row, column];
        }
    }
}
