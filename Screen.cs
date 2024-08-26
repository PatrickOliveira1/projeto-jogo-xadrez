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
                    if (tab.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.piece(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
