class Lasagna
{
    private readonly int _expectedMinutes = 40;
    private readonly int _minutesPerLayer = 2;

    public int ExpectedMinutesInOven() => _expectedMinutes;
    public int RemainingMinutesInOven(int minutes) => _expectedMinutes - minutes;
    public int PreparationTimeInMinutes(int layers) => _minutesPerLayer * layers;

    public int ElapsedTimeInMinutes(int layers, int minutes)
        => PreparationTimeInMinutes(layers) + minutes;
}
