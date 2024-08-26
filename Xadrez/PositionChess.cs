using Tabuleiro;

namespace Xadrez
{
    internal class PositionChess
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public PositionChess()
        {

        }

        public PositionChess(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position toPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
