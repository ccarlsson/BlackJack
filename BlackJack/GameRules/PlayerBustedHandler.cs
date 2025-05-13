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
        
        return NextSuccessor?.HandleStatus(player, dealer)
            ?? throw new InvalidOperationException("No successor found in the chain.");
    }
}
