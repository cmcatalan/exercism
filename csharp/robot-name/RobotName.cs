using System;
using System.Collections.Generic;
using System.Text;

public class Robot
{
    public string Name { get; private set; }
    public Robot() => Reset();
    public void Reset() => Name = RobotName.Generate();
}

internal static class RobotName
{
    private const byte LettersLength = 2, DigitsLength = 3;
    private const char StartLetter = 'A', EndLetter = 'Z';
    private static readonly HashSet<string> _usedNames = new();

    public static string Generate()
    {
        var robotName = GenerateName();
        var isAdded = _usedNames.Add(robotName);

        return !isAdded ? Generate() : robotName;
    }

    private static string GenerateName()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(GenerateLetters(LettersLength));
        stringBuilder.Append(GenerateDigits(DigitsLength));

        return stringBuilder.ToString();
    }

    private static char GenerateLetter() => (char)Random.Shared.Next(StartLetter, EndLetter + 1);

    private static string GenerateDigits(byte digitsLength)
    {
        var maxValueBuilder = new StringBuilder();

        for (int i = 0; i < digitsLength; i++)
            maxValueBuilder.Append(9);

        var maxValue = int.Parse(maxValueBuilder.ToString()) + 1;
        var randomValue = Random.Shared.Next(0, maxValue);

        return randomValue.ToString().PadLeft(digitsLength, '0');
    }

    private static string GenerateLetters(byte lettersLength)
    {
        var stringBuilder = new StringBuilder();

        for (int i = 0; i < lettersLength; i++)
            stringBuilder.Append(GenerateLetter());

        return stringBuilder.ToString();
    }
}