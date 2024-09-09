using projeto_jogo_xadrez;
using Tabuleiro;
using Xadrez;


try
{
    ChessMatch match = new ChessMatch();

    while(!match.Finished)
    {
        Console.Clear();
        Screen.printTabletop(match.Tab);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position origin = Screen.ReadPositionChess().toPosition();

        bool[,] possiblePositions = match.Tab.Piece(origin).PossibleMoviments();

        Console.Clear();
        Screen.printTabletop(match.Tab, possiblePositions);

        Console.WriteLine();
        Console.Write("Destino: ");
        Position destiny = Screen.ReadPositionChess().toPosition();

        match.ExecMoviment(origin, destiny);
    }

    Screen.printTabletop(match.Tab);
}
catch(TabletopException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine();