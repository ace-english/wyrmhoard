using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCoord
{
    public int x, y, z;

    public RoomCoord(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static RoomCoord operator +(RoomCoord a, RoomCoord b)
    {
        RoomCoord ret = b;
        ret.x += a.x;
        ret.y += a.y;
        ret.z += a.z;
        return ret;
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "), floor "+z;
    }
}
