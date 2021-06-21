using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    public static Country[] countries;
    public static Dictionary<Vector2Int, Province> provinces;

    public static void Generate(int _width, int _height, int _countryCount)
    {
        countries = new Country[_countryCount];

        int countryWidth = Mathf.FloorToInt(_width / (float)_countryCount);
        int countryHeight = Mathf.FloorToInt(_height / (float)_countryCount);

        Vector2Int[] origins = new Vector2Int[_countryCount];
        for (int i = 0; i < _countryCount; i++)
            origins[i] = new Vector2Int(Random.Range(0, _width), Random.Range(0, _height));


    }

    private static void ChooseProvinces(int _width, int _height)
    {
        bool unoccupiedProvincesLeft = true;
        while (unoccupiedProvincesLeft)
        {
            unoccupiedProvincesLeft = false;

            for ()
        }
    }
}
