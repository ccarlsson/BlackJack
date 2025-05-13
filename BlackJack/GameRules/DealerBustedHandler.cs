using BlackJack.Models;

namespace BlackJack.GameRules;

public class DealerBustedHandler : StatusHandler
{

    public override GameStatus HandleStatus(Player player, Player dealer)
    {
        if (dealer.BestValue > 21)
        {
            return GameStatus.Won;
        }
        return NextSuccessor?.HandleStatus(player, dealer) 
            ?? throw new InvalidOperationException("No successor found in the chain.");
    }
}
