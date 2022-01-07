using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomIndicator : MonoBehaviour
{
    public GameObject arrowIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
