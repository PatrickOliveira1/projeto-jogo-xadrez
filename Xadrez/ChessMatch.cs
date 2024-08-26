using Tabuleiro;

namespace Xadrez
{
    internal class ChessMatch
    {
        public Tabletop Tab { get; private set; }
        private int Turn { get; set; }
        private Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Tab = new Tabletop(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecMoviment(Position origin, Position destiny)
        {
            Piece p = Tab.RemovePiece(origin);
            p.IncrementQtMoviments();
            Piece catchedPiece = Tab.RemovePiece(destiny);
            Tab.PutPiece(p, destiny);
        }

        private void PutPieces()
        {
            Tab.PutPiece(new Torre(Color.White, Tab), new PositionChess('c',1).toPosition());
            Tab.PutPiece(new Torre(Color.White, Tab), new PositionChess('c',2).toPosition());
            Tab.PutPiece(new Torre(Color.White, Tab), new PositionChess('d',2).toPosition());
            Tab.PutPiece(new Torre(Color.White, Tab), new PositionChess('e',2).toPosition());
            Tab.PutPiece(new Torre(Color.White, Tab), new PositionChess('e',1).toPosition());
            Tab.PutPiece(new Rei(Color.White, Tab), new PositionChess('d',1).toPosition());

            Tab.PutPiece(new Torre(Color.Black, Tab), new PositionChess('c', 7).toPosition());
            Tab.PutPiece(new Torre(Color.Black, Tab), new PositionChess('c', 8).toPosition());
            Tab.PutPiece(new Torre(Color.Black, Tab), new PositionChess('d', 7).toPosition());
            Tab.PutPiece(new Torre(Color.Black, Tab), new PositionChess('e', 7).toPosition());
            Tab.PutPiece(new Torre(Color.Black, Tab), new PositionChess('e', 8).toPosition());
            Tab.PutPiece(new Rei(Color.Black, Tab), new PositionChess('d', 8).toPosition());
        }
    }
}
