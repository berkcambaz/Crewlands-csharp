using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmark
{
    public LandmarkId id;

    public void Build()
    {

    }

    public void Destroy()
    {

    }
}

public enum LandmarkId
{
    None = -1,
    Capital,
    Church,
    Forest,
    Mountains,
    Tower,
    House
}