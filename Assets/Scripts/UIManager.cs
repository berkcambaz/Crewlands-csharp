using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TileUI tileUI;

    public void Init()
    {
        Instance = this;

        tileUI.Init();
    }
}
