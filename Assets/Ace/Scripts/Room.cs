using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public NextRoomIndicator[] indicators;
    public Wall[] walls;
    public GameObject northeastPillar, southeastPillar, southwestPillar, northwestPillar;
    public GameObject decorationRoot;
    private string serialString;
    private RoomCoord coord;

    [Space]
    public GameObject[] decorationPrefabs;

    //can get all torches with just getComponentsInChildren<TorchBehvaior>()

    // Start is called before the first frame update
    public void init(RoomCoord coord)
    {
        this.coord = coord;
        //change surrounding walls to doors
        //interate through each neighboring coord
        //if coord is occupied, 
            //change relevent wall to door
                //do not create wall for each of those
                //deactivate arrow
                //deactivate pillars
            //else, make wall there
                //set up arrow
        //pick random decorations

        //RoomCoord[] neighboringCoords =  new RoomCoord[Enum.GetValues(typeof(Directions)).Length];
        //for
        //foreach (RoomCoord direction in Config.NextDirection)
        RoomCoord currentCoord;
        Room neighboringRoom;
        for (Directions direction = Directions.North; direction < Directions.West; direction++)
        {
            currentCoord = coord + Config.NextDirection[(int)direction];
            if (DungeonRoot.Instance.IsThereARoomAt(currentCoord))
            {
                indicators[(int)direction].gameObject.SetActive(false);
                neighboringRoom = DungeonRoot.Instance.GetRoomAt(currentCoord);
                switch (direction)
                {
                    case Directions.North:
                        northeastPillar.SetActive(false);
                        northwestPillar.SetActive(false);
                        neighboringRoom.walls[(int)Directions.South].SetWallType(Wall.WallType.door);
                        break;
                    default:
                        break;
                }
            }
            else //there is no room there
            {
                indicators[(int)direction].gameObject.SetActive(true);
                indicators[(int)direction].coord = currentCoord;
            }
        }

    }

}
