using BlackJack.Models;

namespace BlackJack.GameRules;

public class CompareValuesHandler : StatusHandler
{
    public override GameStatus HandleStatus(Player player, Player dealer)
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