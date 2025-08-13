using System;
namespace GoFish;

using System.Collections.Generic;
using System.Linq;

public class GameController
{
    private GameState _gameState;
    public bool GameOver { get { return _gameState.GameOver; } }
    public Player HumanPlayer { get { return _gameState.HumanPlayer; } }
    public IEnumerable<Player> Opponents { get { return _gameState.Opponents; } }

    public string Status { get; private set; }

    /// <summary>
    /// Constructs a new GameController
    /// </summary>
    /// <param name="humanPlayerName">Name of the human player</param>
    /// <param name="computerPlayerNames">Names of the computer players</param>
    public GameController(string humanPlayerName, IEnumerable<string> computerPlayerNames)
    {
        _gameState = new GameState(humanPlayerName, computerPlayerNames, new Deck().Shuffle());
        Status = $"Starting a new game with players {string.Join(", ", _gameState.Players)}";
    }

    /// <summary>
    /// Plays the next round, ending the game if everyone ran out of cards
    /// </summary>
    /// <param name="playerToAsk">Which player the human is asking for a card</param>
    /// <param name="valueToAskFor">The value of the card the human is asking for</param>
    public void NextRound(Player playerToAsk, Values valueToAskFor)
    {
        Status = _gameState.PlayRound(_gameState.HumanPlayer, playerToAsk,
            valueToAskFor, _gameState.Stock) + Environment.NewLine;

        ComputerPlayersPlayNextRound();

        Status += string.Join(Environment.NewLine,
            _gameState.Players.Select(player => player.Status));
        Status += $"{Environment.NewLine}The stock has {_gameState.Stock.Count()} cards";

        Status += Environment.NewLine + _gameState.CheckForWinner();
    }


    /// <summary>
    /// All of the computer players that have cards play the next round. If the human is 
    /// out of cards, then the deck is depleted and they play out the rest of the game.
    /// </summary>
    private void ComputerPlayersPlayNextRound()
    {
        IEnumerable<Player> computerPlayersWithCards;
        do
        {
            computerPlayersWithCards =
                _gameState
                    .Opponents
                    .Where(player => player.Hand.Count() > 0);
            foreach (Player player in computerPlayersWithCards)
            {
                var randomPlayer = _gameState.RandomPlayer(player);
                var randomValue = player.RandomValueFromHand();
                Status += _gameState
                              .PlayRound(player, randomPlayer, randomValue, _gameState.Stock)
                          + Environment.NewLine;
            }
        } while ((_gameState.HumanPlayer.Hand.Count() == 0)
                 && (computerPlayersWithCards.Count() > 0));
    }

    /// <summary>
    /// Starts a new game with the same player names
    /// </summary>
    public void NewGame()
    {
        Status = "Starting a new game";
        _gameState = new GameState(_gameState.HumanPlayer.Name,
            _gameState.Opponents.Select(player => player.Name),
            new Deck().Shuffle());
    }
}