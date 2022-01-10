using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public enum WallType {none, wall, door, arch};

    private WallType wallType = 0;
    private bool hasTorches = false;

    public GameObject wallPrefab;
    public GameObject doorPrefab;
    public GameObject doubleTorchWallPrefab;

    public void SetWallType(WallType type)
    {
        //destroy previous prefabs
        //Transform[] components = this.GetComponentsInChildren<Transform>();
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        //if wall type was none, just make sure the torch setting is accurate and we're done
        if(type == WallType.none)
        {
            hasTorches = false;
        }
        
        //replace the torches if it had any
        if (hasTorches)
        {
            AddTorches();
        }
        //add appropriate prefab
        switch (type)
        {
            case WallType.wall:
                Instantiate(wallPrefab, this.transform);
                break;
            case WallType.door:
                Instantiate(doorPrefab, this.transform);
                break;
            default:
                break;
        }
        wallType = type;
    }

    public void AddTorches()
    {
        if (wallType == WallType.none)
            return;
        hasTorches = true;
        Instantiate(doubleTorchWallPrefab, this.transform);
    }


}

