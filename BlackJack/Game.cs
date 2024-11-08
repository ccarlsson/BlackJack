namespace BlackJack;

public class Game
{
    public Player Player { get; set; }
    public Player Dealer { get; set; }
    public Deck Deck { get; set; }
    public GameStatus Status { get; set; }

    private StateHandler _stateHandler = RuleFactory.GetBlackJackRules();

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
        Status = _stateHandler.HandleRequest(Player, Dealer);
     
    }

    public void DealerDraw()
    {
        Dealer.Hand.Add(Deck.Draw());
        Status = _stateHandler.HandleRequest(Player, Dealer); 
    }
}