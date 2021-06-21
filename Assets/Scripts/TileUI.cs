using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUI : MonoBehaviour
{
    public static TileUI Instance;

    public GameObject tileHighlight;

    public void Init() { Instance = this; }

    public void EnableTileHightlight(Vector2 _position)
    {
        tileHighlight.transform.position = new Vector3(_position.x, _position.y, 0f);
        tileHighlight.SetActive(true);
    }

    public void DisableTileHightlight()
    {
        tileHighlight.SetActive(false);
    }
}
