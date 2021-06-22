using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    public static Country[] countries;
    public static Province[] provinces;
    public static int width;
    public static int height;
    public static int countryCount;
    private static SeedRandom srandom;

    public static void Generate(int _width, int _height, int _countryCount, string _seed)
    {
        countries = new Country[_countryCount];
        provinces = new Province[_width * _height];
        width = _width;
        height = _height;
        countryCount = _countryCount;
        srandom = _seed == "" ? new SeedRandom() : new SeedRandom(_seed.GetHashCode());

        ChooseProvinces();

        WorldManager.Instance.SetWorld();
    }

    private static void ChooseProvinces()
    {
        List<Vector2Int>[] origins = new List<Vector2Int>[countryCount];
        for (int countryId = 0; countryId < countryCount; countryId++)
        {
            Vector2Int origin = new Vector2Int(srandom.Range(0, width), srandom.Range(0, height));

            bool sameOriginExists = true;
            while (sameOriginExists)
            {
                if (countryId < 1) break;
                sameOriginExists = false;

                for (int j = 0; j < countryId; j++)
                {
                    if (origin == origins[j][0])
                    {
                        origin = new Vector2Int(srandom.Range(0, width), srandom.Range(0, height));
                        sameOriginExists = true;
                        break;
                    }
                }
            }

            origins[countryId] = new List<Vector2Int>();
            origins[countryId].Add(origin);
            provinces[origin.x + origin.y * width] = new Province((CountryId)countryId);
        }

        bool unoccupiedProvincesLeft = true;
        while (unoccupiedProvincesLeft)
        {
            unoccupiedProvincesLeft = false;

            for (int countryId = 0; countryId < countries.Length; countryId++)
            {
                if (origins[countryId].Count == 0) continue;

                int provinceX = origins[countryId][0].x;
                int provinceY = origins[countryId][0].y;

                int upIndex = (provinceX) + (provinceY - 1) * width;
                int rightIndex = (provinceX + 1) + (provinceY) * width;
                int downIndex = (provinceX) + (provinceY + 1) * width;
                int leftIndex = (provinceX - 1) + (provinceY) * width;

                if (provinceY - 1 > -1 && provinces[upIndex] == null)
                {
                    origins[countryId].Add(new Vector2Int(provinceX, provinceY - 1));
                    provinces[upIndex] = new Province((CountryId)countryId);
                }
                else if (provinceX + 1 < width && provinces[rightIndex] == null)
                {
                    origins[countryId].Add(new Vector2Int(provinceX + 1, provinceY));
                    provinces[rightIndex] = new Province((CountryId)countryId);
                }
                else if (provinceY + 1 < height && provinces[downIndex] == null)
                {
                    origins[countryId].Add(new Vector2Int(provinceX, provinceY + 1));
                    provinces[downIndex] = new Province((CountryId)countryId);
                }
                else if (provinceX - 1 > -1 && provinces[leftIndex] == null)
                {
                    origins[countryId].Add(new Vector2Int(provinceX - 1, provinceY));
                    provinces[leftIndex] = new Province((CountryId)countryId);
                }
                else
                {
                    origins[countryId].RemoveAt(0);
                }

                unoccupiedProvincesLeft |= origins[countryId].Count != 0;
            }
        }
    }

    private static void SprinkleNature()
    {

    }
}
