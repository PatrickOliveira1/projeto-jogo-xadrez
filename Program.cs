using projeto_jogo_xadrez;
using Tabuleiro;
using Xadrez;


try
{
    ChessMatch match = new ChessMatch();

    while(!match.Finished)
    {

        try
        {
            Console.Clear();
            Screen.PrintMatch(match);

            Console.WriteLine();
            Console.Write("Origem: ");
            Position origin = Screen.ReadPositionChess().toPosition();
            match.ValidOriginPosition(origin);

            bool[,] possiblePositions = match.Tab.Piece(origin).PossibleMoviments();

            Console.Clear();
            Screen.PrintTabletop(match.Tab, possiblePositions);

            Console.WriteLine();
            Console.Write("Destino: ");
            Position destiny = Screen.ReadPositionChess().toPosition();
            match.ValidDestinyPosition(origin, destiny);

            match.MakePlay(origin, destiny);
        }
        catch (TabletopException e)
        {
            Console.WriteLine("Erro: " + e.Message);
            Console.ReadLine();
        }
    }

    Screen.PrintTabletop(match.Tab);
}
catch(TabletopException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine();