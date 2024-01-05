namespace OTUS_SOLID.Interfaces;

public interface IGameSettings
{
    int MinNumber { get; set; }
    int MaxNumber { get; set; }
    int Attemps { get; set; }
}