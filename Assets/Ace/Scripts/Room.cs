using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject[] indicators;
    public GameObject[] walls;
    public GameObject northeastPillar, southeastPillar, southwestPillar, northwestPillar;
    public GameObject decorationRoot;
    private string serialString;
    private RoomCoord coord;

    [Space]
    public GameObject wallPrefab;
    public GameObject doorPrefab, doubleTorchWallPrefab;
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
    }
}
