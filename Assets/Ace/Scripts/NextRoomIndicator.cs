using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomIndicator : MonoBehaviour
{
    public GameObject arrowIndicator;
    public RoomCoord coord;

    //on instantiateion, each arrow should generate a ID/coord for its potential position
    private void Awake()
    {
        //edit: nvm all this
        //get parent room's coords
        //name yourself accordingly
        //check dungeon's coords
        //if you have a room there, disable yourself
    }

    void OnMouseEnter()
    {
        arrowIndicator.SetActive(true);
    }
    void OnMouseExit()
    {
        arrowIndicator.SetActive(false);
    }
    void OnMouseDown()
    {
        print("Pribyet!");
        DungeonRoot.Instance.CreateRoom(coord);
    }
}
