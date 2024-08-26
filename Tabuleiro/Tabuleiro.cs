
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

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Row, pos.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatingPosition(pos);
            return Piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new TabletopException("Já existe uma peça nessa posição!");
            }
            Pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Row < 0 || pos.Row >= Row || pos.Column < 0 || pos.Column >= Column)
            {
                return false;
            }
            return true;
        }

        public void ValidatingPosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new TabletopException("Posição Inválida!");
            } 
        }
    }
}
