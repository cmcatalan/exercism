class RemoteControlCar
{
    private const int START_BATTERY = 100, METERS_PER_DRIVE = 20, EMPTY_BATTERY = 0;
    private int _batteryLevel = START_BATTERY;

    public static RemoteControlCar Buy() => new();

    public string DistanceDisplay() => $"Driven {CalculateDrivenMeters()} meters";

    public string BatteryDisplay()
        => _batteryLevel == EMPTY_BATTERY ? "Battery empty" : $"Battery at {_batteryLevel}%";

    public void Drive()
    {
        if (_batteryLevel > EMPTY_BATTERY) _batteryLevel--;
    }

    private int CalculateDrivenMeters() => (START_BATTERY - _batteryLevel) * METERS_PER_DRIVE;
}
