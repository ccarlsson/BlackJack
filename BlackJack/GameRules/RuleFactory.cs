namespace BlackJack.GameRules;

public static class RuleFactory
{
    public static StatusHandler GetBlackJackRules()
    {
        return new BlackJackHandler
        {
            NextSuccessor = new PlayerBustedHandler
            {
                NextSuccessor = new DealerStillInGameHandler
                {
                    NextSuccessor = new DealerBustedHandler
                    {
                        NextSuccessor = new CompareValuesHandler()
                    }
                }
            }
        };
    }
}
