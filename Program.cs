using projeto_jogo_xadrez;
using Tabuleiro;
using Xadrez;

Tabletop tab = new Tabletop(8, 8);

tab.PutPiece(new Torre(Color.Black, tab), new Position(0, 0));
tab.PutPiece(new Torre(Color.Black, tab), new Position(1, 3));
tab.PutPiece(new Rei(Color.Black, tab), new Position(2, 4));

Screen.printTabletop(tab);

Console.WriteLine();