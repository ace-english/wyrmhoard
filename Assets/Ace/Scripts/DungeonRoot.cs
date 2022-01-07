using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoot : MonoBehaviour
{


    #region Singleton
    private static DungeonRoot _instance;
    public static DungeonRoot Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DungeonRoot>();
                if (_instance == null)
                {
                    print("Creating new DungeonRoot!");
                    _instance = new GameObject().AddComponent<DungeonRoot>();
                }
            }
            return _instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
