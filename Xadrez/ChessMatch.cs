using Tabuleiro;

namespace Xadrez
{
    internal class ChessMatch
    {
        public Tabletop Tab { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void MakePlay(Position origin, Position destiny)
        {
            ExecMoviment(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position pos)
        {
            if (Tab.Piece(pos) == null)
            {
                throw new TabletopException("Não existe peça na posição de origem escolhida!");
            }
            if (CurrentPlayer != Tab.Piece(pos).Color)
            {
                throw new TabletopException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Piece(pos).HasPossibleMoviments())
            {
                throw new TabletopException("Não há movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            if (!Tab.Piece(origin).CanMoveFor(destiny))
            {
                throw new TabletopException("Posição de destino inválida");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
