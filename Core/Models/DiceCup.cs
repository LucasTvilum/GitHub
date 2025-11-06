namespace Core.Models;

public class DiceCup
{
    public Dice Die1 { get; } = new Dice();
    public Dice Die2 { get; } = new Dice();

    public (int First, int Second) Roll()
    {
        return (Die1.Roll(), Die2.Roll());
    }
}
