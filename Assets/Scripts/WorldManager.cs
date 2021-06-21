using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    public TileBase[] tilesProvinceOwned;
    public TileBase[] tilesProvinceOccupied;
    public TileBase[] tilesLandmark;
    public TileBase[] tilesArmy;

    public Tilemap tilemapProvince;
    public Tilemap tilemapLandmark;
    public Tilemap tilemapArmy;

    public void Init() { Instance = this; }

    public void SetWorld()
    {
        for (int y = 0; y < World.height; y++)
        {
            for (int x = 0; x < World.width; x++)
            {
                Province province = World.provinces[x + y * World.width];
                tilemapProvince.SetTile(new Vector3Int(x, y, 0), GetProvinceTile(province));
                tilemapLandmark.SetTile(new Vector3Int(x, y, 0), GetLandmarkTile(province));
                tilemapArmy.SetTile(new Vector3Int(x, y, 0), GetArmyTile(province));
            }
        }
    }

    public TileBase GetProvinceTile(Province _province)
    {
        if (_province.ownedBy == CountryId.None && _province.occupiedBy == CountryId.None)
            return null;

        if (_province.occupiedBy != CountryId.None)
            return tilesProvinceOccupied[(int)_province.occupiedBy];
        else
            return tilesProvinceOwned[(int)_province.ownedBy];
    }

    public TileBase GetLandmarkTile(Province _province)
    {
        if (_province.landmark.id == LandmarkId.None)
            return null;

        return tilesLandmark[(int)_province.landmark.id];
    }

    public TileBase GetArmyTile(Province _province)
    {
        if (_province.army.id == CountryId.None)
            return null;

        return tilesArmy[(int)_province.army.id];
    }
}