using BlackJack.Models;

namespace BlackJack.GameRules;

public class BlackJackHandler : StatusHandler
{
    public override GameStatus HandleStatus(Player player, Player dealer)
    {
        if (player.Hand.Count == 2 && player.BestValue == 21)
        {
            return GameStatus.BlackJack;
        }

        return NextSuccessor == null ? 
            throw new Exception("No successor found") : 
            NextSuccessor.HandleStatus(player, dealer);
    }
}
