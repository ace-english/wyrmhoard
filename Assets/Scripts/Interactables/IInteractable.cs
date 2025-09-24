using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{

    public abstract Vector3 GetPosition();
    void OnMouseEnter()
    {
        //startcolor = GetComponent<Renderer>().material.color;
        //GetComponent<Renderer>().material.color = SmartColor.ColorFromHex("71c3e0").Color;
        GameObject.Find("Game").GetComponent<CursorManager>().SetHoverCursor(this);
        //print("hovering "+InteractableName);
    }
    void OnMouseExit()
    {
        //GetComponent<Renderer>().material.color = startcolor;
        CursorManager.Instance.ResetToDefaultCursor();
    }

    //left click handling
    public void OnMouseDown(){
        //print("I am clicked: "+InteractableName);
        Interaction defaultActivity = GetDefaultActivity();
        //if raycast contains a UIManager
        //if(LiveModeUIManager.MenuClicked()==false){
            if(defaultActivity != null){
                defaultActivity.Activate();
            }
        //}
        

    }

    public virtual Interaction GetDefaultActivity()
    {
        return GetInteractionList()[0];
    }

    public abstract List<Interaction> GetInteractionList();

    public string GetName();
}
