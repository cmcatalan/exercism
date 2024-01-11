class RemoteControlCar
{
    private const int START_BATTERY = 100;
    private int batteryLevel;
    private readonly int _speed;
    private readonly int _batteryDrain;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
        batteryLevel = START_BATTERY;
    }

    public bool BatteryDrained() => _batteryDrain > batteryLevel;

    public int DistanceDriven() => (START_BATTERY - batteryLevel) / _batteryDrain * _speed;

    public void Drive()
    {
        if (!BatteryDrained()) batteryLevel -= _batteryDrain;
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

class RaceTrack
{
    private readonly int _distance;

    public RaceTrack(int distance) => _distance = distance;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < _distance)
            car.Drive();

        return car.DistanceDriven() >= _distance;
    }
}
