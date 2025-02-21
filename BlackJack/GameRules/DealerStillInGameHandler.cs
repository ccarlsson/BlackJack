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

        return NextSuccessor == null ?
            throw new Exception("No successor found") :
            NextSuccessor.HandleStatus(player, dealer);
    }
}
