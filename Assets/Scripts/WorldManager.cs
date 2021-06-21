using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    public Tile[] tilesProvinceOwned;
    public Tile[] tilesProvinceOccupied;
    public Tile[] tilesLandmark;
    public Tile[] tilesArmy;

    public Tilemap tilemapProvince;
    public Tilemap tilemapLandmark;
    public Tilemap tilemapArmy;

    public void Init() { Instance = this; }

    public Tile GetProvinceTile(CountryId _countryId, bool _occupied)
    {
        if (_countryId == CountryId.None)
            return null;

        if (_occupied)
            return tilesProvinceOccupied[(int)_countryId];
        else
            return tilesProvinceOwned[(int)_countryId];
    }

    public Tile GetLandmarkTile(LandmarkId _landmarkId)
    {
        if (_landmarkId == LandmarkId.None)
            return null;

        return tilesLandmark[(int)_landmarkId];
    }

    public Tile GetArmyTile(Army _army)
    {
        if (_army.id == CountryId.None)
            return null;

        return tilesArmy[(int)_army.id];
    }
}