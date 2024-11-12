using BlackJack.GameRules;
using BlackJack.Models;

namespace BlackJack;

public class Game
{
    public Player Player { get; set; }
    public Player Dealer { get; set; }
    public Deck Deck { get; set; }
    public GameStatus Status { get; set; }

    private StatusHandler _stateHandler = RuleFactory.GetBlackJackRules();

    public Game()
    {
        Player = new Player();
        Dealer = new Player();
        Deck = new Deck(10);
        Deck.ResetAndShuffle();
        Status = GameStatus.Playing;
    }

    public void Reset()
    {
        Player.Reset();
        Dealer.Reset();
        Status = GameStatus.Playing;
    }

    public void PlayerDraw()
    {
        Player.Hand.Add(Deck.Draw());
        CheckStatus();
    }

    public void DealerDraw()
    {
        Dealer.Hand.Add(Deck.Draw());
        CheckStatus();
    }

    public void CheckStatus()
    {
        Status = _stateHandler.HandleStatus(Player, Dealer);
    }
}