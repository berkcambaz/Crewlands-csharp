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

    public static void Generate(int _width, int _height, int _countryCount)
    {
        countries = new Country[_countryCount];
        provinces = new Province[_width * _height];
        width = _width;
        height = _height;
        countryCount = _countryCount;

        ChooseProvinces();

        WorldManager.Instance.SetWorld();
    }

    private static void ChooseProvinces()
    {
        List<Vector2Int>[] origins = new List<Vector2Int>[countryCount];
        for (int i = 0; i < countryCount; i++)
        {
            origins[i] = new List<Vector2Int>();
            origins[i].Add(new Vector2Int(Random.Range(0, width), Random.Range(0, height)));
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
}
