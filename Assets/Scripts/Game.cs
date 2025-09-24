using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStage{menu, build, raid, rest};

public class Game : MonoBehaviour
{
    static GameStage gameStage;

    public static bool _IsBuildMode()
    {
        return GameObject.Find("Game").GetComponent<Game>().IsBuildMode();
    }

    public bool IsBuildMode()
    {
        return gameStage == GameStage.build;
    }
    
}
