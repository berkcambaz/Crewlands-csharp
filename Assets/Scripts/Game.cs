using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public Camera cam;

    public WorldManager worldManager;
    public UIManager uiManager;

    private void Awake()
    {
        Instance = this;

        // Initialize managers
        worldManager.Init();
        uiManager.Init();

        World.Generate(10, 10, 3);
    }
}
