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

        
        return NextSuccessor?.HandleStatus(player, dealer)
            ?? throw new InvalidOperationException("No successor found in the chain.");
    }
}
