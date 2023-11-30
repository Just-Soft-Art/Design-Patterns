var settlersOfCatan = new SettlersOfCatan();
settlersOfCatan.Play();

Console.WriteLine();

var terraformingMars = new TerraformingMars();
terraformingMars.Play();

Console.ReadKey();

abstract class BoardGame
{
    protected Random Random = new Random();

    public void Play()
    {
        SetupBoard();
        bool isFinished = false;
        while (!isFinished)
        {
            isFinished = PlayTurn();
        }
        SelectWinner();
    }

    protected abstract void SetupBoard();
    protected abstract bool PlayTurn();
    protected abstract void SelectWinner();
}

class SettlersOfCatan : BoardGame
{
    protected override void SetupBoard()
    {
        Console.WriteLine("Randomly placing hexagonal tiles.");
    }

    protected override bool PlayTurn()
    {
        Console.WriteLine("Building, trading, etc.");
        return Random.Next(5) >= 4;
    }

    protected override void SelectWinner()
    {
        Console.WriteLine(
            "Winner is the one who first got 12 points");
    }
}

class TerraformingMars : BoardGame
{
    private Random _random = new Random();

    protected override void SetupBoard()
    {
        Console.WriteLine("Choosing from two available maps.");
    }

    protected override bool PlayTurn()
    {
        Console.WriteLine(
            "Raising oxygen level, placing oceans, etc.");
        return _random.Next(5) >= 4;
    }

    protected override void SelectWinner()
    {
        Console.WriteLine(
            "Winner is the one with most points at game's end.");
    }
}