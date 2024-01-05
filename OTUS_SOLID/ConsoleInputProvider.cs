using OTUS_SOLID.Interfaces;

namespace OTUS_SOLID;

public class ConsoleInputProvider: IInputProvider
{
    public int InputMinNumber()
    {
        Console.WriteLine("Input min number: ");
        if (!int.TryParse(Console.ReadLine(), out var number))
        {
            throw new ArgumentException();
        }
        return number;
    }

    public int InputMaxNumber()
    {
        Console.WriteLine("Input max number: ");
        if (!int.TryParse(Console.ReadLine(), out var number))
        {
            throw new ArgumentException();
        }
        return number;
    }

    public int InputQuantityAttemps()
    {
        Console.WriteLine("Input attems quantity: ");
        if (!int.TryParse(Console.ReadLine(), out var number))
        {
            throw new ArgumentException();
        }
        return number;
    }

    public int InputNumber()
    {
        Console.WriteLine("Input number: ");
        if (!int.TryParse(Console.ReadLine(), out var number))
        {
            throw new ArgumentException();
        }
        return number;
    }
}