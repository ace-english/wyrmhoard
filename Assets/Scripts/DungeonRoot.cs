using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoot : MonoBehaviour
{
    //dictionary of coords, room pointers (or room serial/string encoders)
    public GameObject roomPrefab;
    private Dictionary<RoomCoord,Room> dungeonMap;

    public bool BuildMode, DeleteMode, RedecorateMode;

    [Space]
    public GameObject[] decorationPrefabs_center;
    public GameObject[] decorationPrefabs_misc;
    public GameObject[] decorationPrefabs_wall;

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

    private void Awake()
    {
        if (_instance != null) Destroy(this);
        dungeonMap = new Dictionary<RoomCoord, Room>();

        CreateRoom(new RoomCoord(0, 0, 0));
    }

    public void CreateRoom(RoomCoord coord)
    {
        if (!IsThereARoomAt(coord))
        {
            //may change axes later
            float x = coord.x * 2;
            float z = coord.y * 2;
            float y = coord.z;

            //calculate transform
            Vector3 newRoomTransform = new Vector3(x, y, z);

            //make prefab there
            GameObject newRoomGO = Instantiate(roomPrefab, newRoomTransform, Quaternion.identity);
            newRoomGO.transform.SetParent(this.gameObject.transform);
            Room newRoom = newRoomGO.GetComponent<Room>();
            newRoom.init(coord);

            //add to dictionary
            dungeonMap.Add(coord, newRoom);
            foreach (KeyValuePair<RoomCoord, Room> pair in dungeonMap){
                print(pair.Key.ToString() + ": " + pair.Value);
            }

        }
    }

    public bool IsThereARoomAt(RoomCoord coord)
    {
        print("checking for " + coord.ToString());
        return dungeonMap.ContainsKey(coord);
    }

    public Room GetRoomAt(RoomCoord coord)
    {
        Room room;
        if(dungeonMap.TryGetValue(coord, out room))
        {
            return room;
        }
        return null;
    }

    public void RemoveRoom(RoomCoord coord)
    {
        Room room = GetRoomAt(coord);
        room.RemoveNeighboringDoors();
        dungeonMap.Remove(coord);
        GameObject.Destroy(room.gameObject);
        //TODO: ask pathfinder if all rooms are accessible

        if (dungeonMap.Count <= 1)
        {
            DeleteMode = false;
        }

    }

    public void EnableBuildMode()
    {
        BuildMode = true;
        DeleteMode = false;
        RedecorateMode = false;
    }

    public void EnableRedecorateMode()
    {
        BuildMode = false;
        DeleteMode = false;
        RedecorateMode = true;
    }

    public void EnableDeleteMode()
    {
        if (dungeonMap.Count > 1)
        {
            BuildMode = false;
            DeleteMode = true;
            RedecorateMode = false;
        }
    }
}
