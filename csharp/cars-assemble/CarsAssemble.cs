static class AssemblyLine
{
    private const double ZERO_PERCENT = 0, HUNDRED_PERCENT = 1, NINETY_PERCENT = 0.90, EIGHTY_PERCENT = 0.80, SEVENTYSEVEN_PERCENT = 0.77;
    private const int ZERO_PERCENT_MAX_SPEED = 0, HUNDRED_PERCENT_MAX_SPEED = 4, NINETY_PERCENT_MAX_SPEED = 8, EIGHTY_PERCENT_MAX_SPEED = 9;
    private const int CARS_HOUR = 221, MINUTES_PER_HOUR = 60;

    public static double SuccessRate(int speed)
        => speed switch
        {
            ZERO_PERCENT_MAX_SPEED => ZERO_PERCENT,
            <= HUNDRED_PERCENT_MAX_SPEED => HUNDRED_PERCENT,
            <= NINETY_PERCENT_MAX_SPEED => NINETY_PERCENT,
            EIGHTY_PERCENT_MAX_SPEED => EIGHTY_PERCENT,
            _ => SEVENTYSEVEN_PERCENT
        };

    public static double ProductionRatePerHour(int speed)
        => CARS_HOUR * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed)
        => (int)(ProductionRatePerHour(speed) / MINUTES_PER_HOUR);
}
