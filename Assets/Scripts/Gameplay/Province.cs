using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Province
{
    public CountryId ownedBy;
    public CountryId occupiedBy;
    public Landmark landmark;
    public Army army;

    public Province(CountryId _ownedBy)
    {
        ownedBy = _ownedBy;
        occupiedBy = CountryId.None;
        landmark = new Landmark(LandmarkId.None);
        army = new Army(CountryId.None);
    }

    public Province(CountryId _ownedBy, CountryId _occupiedBy, Landmark _landmark, Army _army)
    {
        ownedBy = _ownedBy;
        occupiedBy = _occupiedBy;
        landmark = _landmark;
        army = _army;
    }
}
