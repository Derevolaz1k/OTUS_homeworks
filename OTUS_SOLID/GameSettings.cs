using OTUS_SOLID.Interfaces;

namespace OTUS_SOLID;

public class GameSettings: IGameSettings
{
    public GameSettings(int minNumber, int maxNumber, int attemps)
    {
        MinNumber = minNumber;
        MaxNumber = maxNumber;
        Attemps = attemps;
    }

    public int MinNumber { get; set; }
    public int MaxNumber { get; set; }
    public int Attemps { get; set; }
}