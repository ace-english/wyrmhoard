using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction
{
    private string label;
    public InteractableObject AssociatedInteractable;

    public Interaction (InteractableObject associatedInteractable){
        this.AssociatedInteractable = associatedInteractable;
        label = associatedInteractable.GetName();
    }

    //checked at time of clicking on the object
    public virtual bool IsActivatable(){ return true;}
    public virtual void Activate(Entity entity){
    }

    public abstract void Activate();

    public virtual string GetLabel(){return label;}
    public virtual void SetLabel(string label){this.label = label;}

}
