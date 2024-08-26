using Tabuleiro;

namespace projeto_jogo_xadrez
{
    internal class Screen
    {
        public static void printTabletop(Tabletop tab)
        {
            for (int i = 0; i < tab.Row; i++)
            {
                for (int j = 0; j < tab.Column; j++)
                {
                    if (tab.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Piece(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
