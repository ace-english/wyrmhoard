
using UnityEngine;

public class Floor : MonoBehaviour{

    public GameObject floorPrefab;
    public GameObject chasmPrefab;

    bool isChasm;

    public void SetFloorType(){
        //first, clear
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        //add appropriate prefab
        if (isChasm)
            Instantiate(chasmPrefab, this.transform);
        else
            Instantiate(floorPrefab, this.transform);
        
    }
    public void SetChasm(bool chasm){
        isChasm = chasm;
        SetFloorType();
    }
    public void ToggleChasm(){
        isChasm = !isChasm;
        SetFloorType();
    }
}