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

    public void init(RoomCoord coord)
    {
        print("Setting up room at " + coord.ToString());
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
        for (Directions direction = Directions.North; direction <= Directions.West; direction++)
        {
            print("Currently looking at " + direction);
            currentCoord = coord + Config.NextDirection[(int)direction];
            //print("CurrentCord: " + currentCoord.ToString());
            if (DungeonRoot.Instance.IsThereARoomAt(currentCoord))
            {
                print("Room found at " + currentCoord.ToString());
                indicators[(int)direction].gameObject.SetActive(false);
                neighboringRoom = DungeonRoot.Instance.GetRoomAt(currentCoord);
                switch (direction)
                {
                    case Directions.North:
                        print("Disabling setting north wall to " + Wall.WallType.door + " of room " + neighboringRoom.coord.ToString());
                        northeastPillar.SetActive(false);
                        northwestPillar.SetActive(false);
                        neighboringRoom.walls[(int)Directions.South].SetWallType(Wall.WallType.door);
                        neighboringRoom.indicators[(int)Directions.South].gameObject.SetActive(false);
                        break;
                    case Directions.East:
                        print("Disabling setting East wall to " + Wall.WallType.door + " of room " + neighboringRoom.coord.ToString());
                        northeastPillar.SetActive(false);
                        southeastPillar.SetActive(false);
                        neighboringRoom.walls[(int)Directions.West].SetWallType(Wall.WallType.door);
                        neighboringRoom.indicators[(int)Directions.West].gameObject.SetActive(false);
                        break;
                    case Directions.South:
                        print("Disabling setting South wall to " + Wall.WallType.door + " of room " + neighboringRoom.coord.ToString());
                        southeastPillar.SetActive(false);
                        southwestPillar.SetActive(false);
                        neighboringRoom.walls[(int)Directions.North].SetWallType(Wall.WallType.door);
                        neighboringRoom.indicators[(int)Directions.North].gameObject.SetActive(false);
                        break;
                    case Directions.West:
                        print("Disabling setting West wall to " + Wall.WallType.door + " of room " + neighboringRoom.coord.ToString());
                        southwestPillar.SetActive(false);
                        northwestPillar.SetActive(false);
                        neighboringRoom.walls[(int)Directions.East].SetWallType(Wall.WallType.door);
                        neighboringRoom.indicators[(int)Directions.East].gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
            else //there is no room there
            {
                print("No room fount at " + currentCoord.ToString());
                indicators[(int)direction].gameObject.SetActive(true);
                indicators[(int)direction].coord = currentCoord;

                switch (direction)
                {
                    case Directions.North:
                        print("Setting north wall to " + Wall.WallType.wall + " of room " + coord.ToString());
                        walls[(int)Directions.North].SetWallType(Wall.WallType.wall);
                        break;
                    case Directions.East:
                        print("Setting East wall to " + Wall.WallType.wall + " of room " + coord.ToString());
                        walls[(int)Directions.East].SetWallType(Wall.WallType.wall);
                        break;
                    case Directions.South:
                        print("Setting South wall to " + Wall.WallType.wall + " of room " + coord.ToString());
                        walls[(int)Directions.South].SetWallType(Wall.WallType.wall);
                        break;
                    case Directions.West:
                        print("Setting West wall to " + Wall.WallType.wall + " of room " + coord.ToString());
                        walls[(int)Directions.West].SetWallType(Wall.WallType.wall);
                        break;
                    default:
                        break;
                }
            }
        }
        walls[(int)Directions.North].AddTorches();
        walls[(int)Directions.South].AddTorches();

    }

    public void RemoveNeighboringDoors()
    {
        RoomCoord currentCoord;
        Room neighboringRoom;
        for (Directions direction = Directions.North; direction <= Directions.West; direction++)
        {
            print("Currently looking at " + direction);
            currentCoord = coord + Config.NextDirection[(int)direction];
            //print("CurrentCord: " + currentCoord.ToString());
            if (DungeonRoot.Instance.IsThereARoomAt(currentCoord))
            {
                print("Room found at " + currentCoord.ToString());
                indicators[(int)direction].gameObject.SetActive(false);
                neighboringRoom = DungeonRoot.Instance.GetRoomAt(currentCoord);
                switch (direction)
                {
                    case Directions.North:
                        neighboringRoom.southeastPillar.SetActive(true);
                        neighboringRoom.southwestPillar.SetActive(true);
                        neighboringRoom.walls[(int)Directions.South].SetWallType(Wall.WallType.wall);
                        neighboringRoom.indicators[(int)Directions.South].gameObject.SetActive(true);
                        neighboringRoom.indicators[(int)Directions.South].coord = this.coord;
                        break;
                    case Directions.East:
                        neighboringRoom.northwestPillar.SetActive(true);
                        neighboringRoom.southwestPillar.SetActive(true);
                        neighboringRoom.walls[(int)Directions.West].SetWallType(Wall.WallType.wall);
                        neighboringRoom.indicators[(int)Directions.West].gameObject.SetActive(true);
                        neighboringRoom.indicators[(int)Directions.West].coord = this.coord;
                        break;
                    case Directions.South:
                        neighboringRoom.northeastPillar.SetActive(true);
                        neighboringRoom.northwestPillar.SetActive(true);
                        neighboringRoom.walls[(int)Directions.North].SetWallType(Wall.WallType.wall);
                        neighboringRoom.indicators[(int)Directions.North].gameObject.SetActive(true);
                        neighboringRoom.indicators[(int)Directions.North].coord = this.coord;
                        break;
                    case Directions.West:
                        neighboringRoom.southeastPillar.SetActive(true);
                        neighboringRoom.northeastPillar.SetActive(true);
                        neighboringRoom.walls[(int)Directions.East].SetWallType(Wall.WallType.wall);
                        neighboringRoom.indicators[(int)Directions.East].gameObject.SetActive(true);
                        neighboringRoom.indicators[(int)Directions.East].coord = this.coord;
                        break;
                    default:
                        break;
                }
            }
        }
    }


    void OnMouseDown()
    {
        if (DungeonRoot.Instance.DeleteMode)
        {
            DungeonRoot.Instance.RemoveRoom(this.coord);
        }
    }
}
