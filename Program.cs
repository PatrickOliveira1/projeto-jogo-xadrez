using projeto_jogo_xadrez;
using Tabuleiro;
using Xadrez;


try
{
    Tabletop tab = new Tabletop(8, 8);

    tab.PutPiece(new Torre(Color.Black, tab), new Position(0, 0));
    tab.PutPiece(new Torre(Color.Black, tab), new Position(1, 3));
    tab.PutPiece(new Rei(Color.Black, tab), new Position(0, 2));

    Screen.printTabletop(tab);
}
catch(TabletopException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine();