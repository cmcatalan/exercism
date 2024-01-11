class BirdCount
{
    private readonly int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay) => _birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => new[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => _birdsPerDay[^1];

    public void IncrementTodaysCount() => _birdsPerDay[^1]++;

    public bool HasDayWithoutBirds()
    {
        for (int i = 0; i < _birdsPerDay.Length; i++)
            if (_birdsPerDay[i] == 0) return true;

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birdSum = 0;

        if (numberOfDays > _birdsPerDay.Length)
            numberOfDays = _birdsPerDay.Length;

        for (int i = 0; i < numberOfDays; i++)
            birdSum += _birdsPerDay[i];

        return birdSum;
    }

    public int BusyDays()
    {
        int busyDays = 0;

        for (int i = 0; i < _birdsPerDay.Length; i++)
            if (_birdsPerDay[i] >= 5) busyDays++;

        return busyDays;
    }
}
