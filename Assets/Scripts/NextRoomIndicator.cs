using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomIndicator : MonoBehaviour
{
    public GameObject arrowIndicator;
    public RoomCoord coord;

    void OnMouseEnter()
    {
        if(DungeonRoot.Instance.BuildMode)
            arrowIndicator.SetActive(true);
    }
    void OnMouseExit()
    {
        arrowIndicator.SetActive(false);
    }
    void OnMouseDown()
    {
        if (DungeonRoot.Instance.BuildMode)
        {
            print("creating new room at " + coord.ToString());
            DungeonRoot.Instance.CreateRoom(coord);
        }
    }
}
