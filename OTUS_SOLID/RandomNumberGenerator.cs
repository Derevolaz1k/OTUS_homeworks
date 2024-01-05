using OTUS_SOLID.Interfaces;

namespace OTUS_SOLID;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _rnd;

    public RandomNumberGenerator()
    {
        _rnd = new Random();
    }

    public int GenerateNumber(int minNumber, int maxNumber) => _rnd.Next(minNumber, maxNumber);
}