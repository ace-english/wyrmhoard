using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoot : MonoBehaviour
{
    //dictionary of coords, room pointers (or room serial/string encoders)
    public GameObject roomPrefab;
    Dictionary<RoomCoord,Room> dungeonMap;

    #region Singleton
    private static DungeonRoot _instance;
    public static DungeonRoot Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DungeonRoot>();
                if (_instance == null)
                {
                    print("Creating new DungeonRoot!");
                    _instance = new GameObject().AddComponent<DungeonRoot>();
                }
            }
            return _instance;
        }
    }
    #endregion

    public void CreateRoom(RoomCoord coord)
    {

    }
}
