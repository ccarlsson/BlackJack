using BlackJack.Models;

namespace BlackJack.GameRules;

public class PlayerBustedHandler : StatusHandler
{

    public override GameStatus HandleStatus(Player player, Player dealer)
    {
        if (player.BestValue > 21)
        {
            return GameStatus.Lost;
        }
        if (NextSuccessor == null) throw new Exception("No successor found");

        return NextSuccessor.HandleStatus(player, dealer);
    }
}
