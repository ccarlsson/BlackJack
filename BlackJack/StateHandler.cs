namespace BlackJack;

public abstract class StateHandler
{
    public StateHandler? NextSuccessor {  get; set; }
    public abstract GameStatus HandleRequest(Player player, Player dealer);
    
}


public static class  RuleFactory
{
    public static StateHandler GetBlackJackRules()
    {
        return new BlackJackHandler()
            .NextSuccessor =  new PlayerBustedHandler()
            .NextSuccessor = new DealerStillInGameHandler()
            .NextSuccessor = new DealerBustedHandler()
            .NextSuccessor = new CompareValuesHandler();
    }
}

public class BlackJackHandler : StateHandler
{
    public override GameStatus HandleRequest(Player player, Player dealer)
    {
        if (player.Hand.Count == 2 && player.BestValue == 21)
        {
            return GameStatus.BlackJack;
        }
        if (NextSuccessor == null) throw new Exception("No successor found");
        return NextSuccessor.HandleRequest(player, dealer);
    }
}

public class PlayerBustedHandler : StateHandler 
{

    public override GameStatus HandleRequest(Player player, Player dealer)
    {
        if (player.BestValue > 21)
        {
            return GameStatus.Lost;
        }
        if (NextSuccessor == null) throw new Exception("No successor found");

        return NextSuccessor.HandleRequest(player, dealer);
    }
}

public class DealerStillInGameHandler : StateHandler
{
    public override GameStatus HandleRequest(Player player, Player dealer)
    {

        if (dealer.Hand.Count == 2 || dealer.BestValue <= 16)
        {
            return GameStatus.Playing;
        }
        if (NextSuccessor== null) throw new Exception("No successor found");
        return NextSuccessor.HandleRequest(player, dealer);
    }
}

public class DealerBustedHandler : StateHandler
{

    public override GameStatus HandleRequest(Player player, Player dealer)
    {
        if (dealer.BestValue > 21)
        {
            return GameStatus.Won;
        }
        if (NextSuccessor == null) throw new Exception("No successor found");

        return NextSuccessor.HandleRequest(player, dealer);
    }
}

public class CompareValuesHandler : StateHandler
{
    public override GameStatus HandleRequest(Player player, Player dealer)
    {
        if (dealer.BestValue == player.BestValue)
        {
            return GameStatus.Tie;
        }
        else if (dealer.BestValue > player.BestValue)
        {
            return GameStatus.Lost;
        }
        else
        {
            return GameStatus.Won;
        }
    }
}