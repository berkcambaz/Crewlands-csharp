using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public WorldManager worldManager;

    private void Awake()
    {
        Instance = this;

        // Initialize managers
        worldManager.Init();

        World.Generate(10, 10, 3);
    }
}
