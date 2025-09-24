using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions { North, East, South, West, Up, Down};

public static class Config
{
    public static RoomCoord north = new RoomCoord(0, -1, 0);
    public static RoomCoord east = new RoomCoord(-1, 0, 0);
    public static RoomCoord south = new RoomCoord(0, 1, 0);
    public static RoomCoord west = new RoomCoord(1, 0, 0);
    public static RoomCoord up = new RoomCoord(0, 0, 1);
    public static RoomCoord down = new RoomCoord(0, 0, -1);

    public static RoomCoord[] NextDirection = { north, east, south, west, up, down };
}
