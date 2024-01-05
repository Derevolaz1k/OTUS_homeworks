using System;

using OTUS_SOLID.Interfaces;

namespace OTUS_SOLID
{
    public class Game : IGame
    {
        private readonly IGameSettings _gameSettings;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IInputProvider _inputProvider;

        private int _targetNumber;
        private int _attemptsLeft;

        public Game(IGameSettings gameSettings, IRandomNumberGenerator randomNumberGenerator, IInputProvider inputProvider)
        {
            _gameSettings = gameSettings ?? throw new ArgumentNullException(nameof(gameSettings));
            _randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
            _inputProvider = inputProvider ?? throw new ArgumentNullException(nameof(inputProvider));

            _attemptsLeft = _gameSettings.Attemps;
        }

        public void StartGame()
        {
            Console.WriteLine($"Welcome to the Guess Number Game! Try to guess a number between {_gameSettings.MinNumber} and {_gameSettings.MaxNumber}.");
            
            _targetNumber = _randomNumberGenerator.GenerateNumber(_gameSettings.MinNumber, _gameSettings.MaxNumber);

            while (_attemptsLeft > 0)
            {
                var userGuess = _inputProvider.InputNumber();

                if (userGuess == _targetNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the correct number!");
                    GameOver();
                    break;
                }

                Console.WriteLine(userGuess < _targetNumber ? "Too low. Try again!" : "Too high. Try again!");
                _attemptsLeft--;
            }

            if (_attemptsLeft != 0) return;
            Console.WriteLine($"Sorry, you've run out of attempts. The correct number was {_targetNumber}.");
            GameOver();
        }

        public void GameOver()
        {
            Console.WriteLine("Game Over!");
        }
    }
}