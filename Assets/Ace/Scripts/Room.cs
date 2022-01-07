using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject[] indicators;
    public GameObject[] walls;
    public GameObject decorationRoot;
    private string serialString;

    [Space]
    public GameObject wallPrefab;
    public GameObject doorPrefab, doubleTorchWallPrefab;
    public GameObject[] decorationPrefabs;

    //can get all torches with just getComponentsInChildren<TorchBehvaior>()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
