using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;
    public float scrollSpeed;
    private float scroll;

    private Vector3 dragOrigin;

    void Start()
    {
        scroll = Game.Instance.cam.orthographicSize;
    }

    void Update()
    {
        // If mouse is over UI, cancel any tile related UI
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 offset = Game.Instance.cam.ScreenToWorldPoint(dragOrigin) - Game.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
            Game.Instance.cam.transform.Translate(offset);
            dragOrigin = Input.mousePosition;
        }

        Vector2Int targetTile = Vector2Int.FloorToInt(Game.Instance.cam.ScreenToWorldPoint(Input.mousePosition));
        TileUI.Instance.EnableTileHightlight(targetTile);

        scroll = Mathf.Clamp(scroll - (Input.mouseScrollDelta.y * Time.deltaTime * 25f), zoomMin, zoomMax);
        Game.Instance.cam.orthographicSize = Mathf.Lerp(Game.Instance.cam.orthographicSize, scroll, Time.deltaTime * 5f);
    }
}
