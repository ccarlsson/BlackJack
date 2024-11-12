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
        if (NextSuccessor == null) throw new Exception("No successor found");

        return NextSuccessor.HandleStatus(player, dealer);
    }
}
