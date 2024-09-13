using System.Collections.Generic;
using Tabuleiro;
using Xadrez;

namespace projeto_jogo_xadrez
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintTabletop(match.Tab);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn);
            Console.WriteLine("Aguardando jogada: " + match.CurrentPlayer);
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            PrintSet(match.Captured(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.Captured(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintTabletop(Tabletop tab)
        {
            for (int i = 0; i < tab.Row; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Column; j++)
                {
                    PrintPiece(tab.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintTabletop(Tabletop tab, bool[,] possiblePositions)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Row; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Column; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    PrintPiece(tab.Piece(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PositionChess ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new PositionChess(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}
