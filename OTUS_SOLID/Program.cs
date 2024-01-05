using OTUS_SOLID;
using OTUS_SOLID.Interfaces;

IInputProvider inputProvider = new ConsoleInputProvider();
var minNumber = inputProvider.InputMinNumber();
var maxNumber = inputProvider.InputMaxNumber();
var attemps = inputProvider.InputQuantityAttemps();

IRandomNumberGenerator generator = new RandomNumberGenerator();

IGameSettings settings = new GameSettings(minNumber,maxNumber,attemps);

IGame game = new Game(gameSettings: settings, randomNumberGenerator: generator, inputProvider: inputProvider);
game.StartGame();