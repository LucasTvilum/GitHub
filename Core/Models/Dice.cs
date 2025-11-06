namespace Core.Models;

public class Dice
{
    private static readonly Random Rng = new Random();

    public int Value { get; private set; } = 1;

    public int Roll()
    {
        Value = Rng.Next(1, 7); // 1..6
        return Value;
    }
}
