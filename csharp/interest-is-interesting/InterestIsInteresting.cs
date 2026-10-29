static class SavingsAccount
{
    private const float NegativeInterest = 3.213f;
    private const float Under1K = 0.5f;
    private const float Under5K = 1.621f;
    private const float Above5K = 2.475f;

    public static float InterestRate(decimal balance)
    {
        return balance switch
        {
            < 0 => NegativeInterest,
            < 1000 => Under1K,
            < 5000 => Under5K,
            _ => Above5K
        };
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }

        return years;
    }
}
