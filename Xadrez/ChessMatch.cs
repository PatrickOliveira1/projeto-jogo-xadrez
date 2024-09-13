using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    internal class ChessMatch
    {
        public Tabletop Tab { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces { get; set; }
        private HashSet<Piece> CapturedPieces { get; set; }

        public ChessMatch()
        {
            Tab = new Tabletop(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PutPieces();
        }

        public void ExecMoviment(Position origin, Position destiny)
        {
            Piece p = Tab.RemovePiece(origin);
            p.IncrementQtMoviments();
            Piece catchedPiece = Tab.RemovePiece(destiny);
            Tab.PutPiece(p, destiny);
            if (catchedPiece != null)
            {
                CapturedPieces.Add(catchedPiece);
            }
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

        public HashSet<Piece> Captured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(Captured(color));
            return aux;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Tab.PutPiece(piece, new PositionChess(column, row).toPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Torre(Color.White, Tab));
            PutNewPiece('c', 2, new Torre(Color.White, Tab));
            PutNewPiece('d', 2, new Torre(Color.White, Tab));
            PutNewPiece('e', 2, new Torre(Color.White, Tab));
            PutNewPiece('e', 1, new Torre(Color.White, Tab));
            PutNewPiece('d', 1, new Rei(Color.White, Tab));

            PutNewPiece('c', 7, new Torre(Color.Black, Tab));
            PutNewPiece('c', 8, new Torre(Color.Black, Tab));
            PutNewPiece('d', 7, new Torre(Color.Black, Tab));
            PutNewPiece('e', 7, new Torre(Color.Black, Tab));
            PutNewPiece('e', 8, new Torre(Color.Black, Tab));
            PutNewPiece('d', 8, new Rei(Color.Black, Tab));
        }
    }
}
