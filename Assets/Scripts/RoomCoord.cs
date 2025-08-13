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
        //Debug.Log(a.ToString() + " + " + b.ToString());
        RoomCoord ret = new RoomCoord(b.x, b.y, b.z);
        ret.x += a.x;
        ret.y += a.y;
        ret.z += a.z;
        //Debug.Log("= " + ret.ToString());
        return ret;
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "), floor "+z;
    }

    public override bool Equals(object obj)
    {
        var coord = obj as RoomCoord;

        if (coord == null)
            return false;

        return x.Equals(coord.x) &&
               y.Equals(coord.y) &&
               z.Equals(coord.z);
    }


    //Credit to Jon Skeet from https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
    //  for inspiration for this method
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = (int)2166136261;
            // Suitable nullity checks etc, of course :)
            hash = hash * 16777619 ^ x.GetHashCode();
            hash = hash * 16777619 ^ y.GetHashCode();
            hash = hash * 16777619 ^ z.GetHashCode();
            return hash;
        }
    }
}
