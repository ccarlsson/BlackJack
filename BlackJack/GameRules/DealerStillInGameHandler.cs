using BlackJack.Models;

namespace BlackJack.GameRules;

public class DealerStillInGameHandler : StatusHandler
{
    public override GameStatus HandleStatus(Player player, Player dealer)
    {

        if (dealer.Hand.Count < 2 || dealer.BestValue <= 16)
        {
            return GameStatus.Playing;
        }

        if (NextSuccessor == null) throw new Exception("No successor found");
        return NextSuccessor.HandleStatus(player, dealer);
    }
}
