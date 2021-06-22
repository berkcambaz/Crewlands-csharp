using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SeedRandom
{
    System.Random random;

    public SeedRandom()
    {
        random = new System.Random(Time.time.ToString().GetHashCode());
    }

    public SeedRandom(int _seed)
    {
        random = new System.Random(_seed);
    }

    public int Number(int _minInclusive, int _maxExclusive)
    {
        return random.Next(_minInclusive, _maxExclusive);
    }

    public int Percent(int[,] _cases)
    {
#if DEBUG
        int sum = 0;
        for (int i = 0; i < _cases.GetLength(0); i++) sum += _cases[i, 0];
        if (sum != 100) Debug.LogError("Sum of chances must be equal to 100!");
#endif

        int percentage = Number(0, 100);
        int previousPercent = 0;
        for (int i = 0; i < _cases.GetLength(0); i++)
        {
            if (previousPercent - 1 < percentage && percentage < previousPercent + _cases[i, 0]) return _cases[i, 1];
            previousPercent += _cases[i, 0];
        }

        return _cases[_cases.GetLength(0) - 1, 1];
    }

    public int Dice(int _bonus)
    {
        return Number(0, 6) + _bonus;
    }
}
