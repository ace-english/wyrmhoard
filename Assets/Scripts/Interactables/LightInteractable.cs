using System;
using System.Collections.Generic;
using UnityEngine;

//aka furniture definition with lights
public class LightInteractable : InteractableObject
{
    public Transform position;
    public bool flicker;
    public Color color;
    public ToggleGameObjectInteraction toggleLightInteraction;

    public GameObject LightsParent; //GO that is parent to one or more lights/particle effects
                                    //gas gets turned on/off. ideal for city lighting

    public void Init()
    {
        toggleLightInteraction = new ToggleGameObjectInteraction(this as InteractableObject);
        toggleLightInteraction.Fire = LightsParent;
        toggleLightInteraction.SetLabel("Light");
    }

    public bool IsLit()
    {
        return toggleLightInteraction.ToggleItemIsActive();
    }
}
