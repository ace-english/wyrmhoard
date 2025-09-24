using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ToggleGameObjectInteraction : Interaction
{

    public GameObject Fire;
    public string TurnOffLabel;

    public bool requireToolsForOn = true;
    public bool requireToolsForOff = false;

    public ToggleGameObjectInteraction(InteractableObject associatedInteractable) : base(associatedInteractable)
    {
    }

    public override void Activate()
    {
        if(Fire.activeInHierarchy==false)
            Fire.SetActive(true);
        else
            Fire.SetActive(false);

    }
    public bool ToggleItemIsActive(){
        return Fire.activeSelf;
    }
    

    public override string GetLabel(){
        if(ToggleItemIsActive())
            return TurnOffLabel;
        else
            return base.GetLabel();
    }
}