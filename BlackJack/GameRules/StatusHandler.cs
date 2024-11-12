using BlackJack.Models;

namespace BlackJack.GameRules;

public abstract class StatusHandler
{
    public StatusHandler? NextSuccessor { get; set; }
    public abstract GameStatus HandleStatus(Player player, Player dealer);
}
