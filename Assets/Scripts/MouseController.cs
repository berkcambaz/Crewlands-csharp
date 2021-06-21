using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;
    public float scrollSpeed;
    public float scroll;

    void Start()
    {
        scroll = Game.Instance.cam.orthographicSize;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Vector2 targetTile = Game.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
        TileUI.Instance.EnableTileHightlight(Vector2Int.RoundToInt(targetTile));
    }
}
