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

    public int Range(int _minInclusive, int _maxExclusive)
    {
        return random.Next(_minInclusive, _maxExclusive);
    }
}
