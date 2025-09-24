using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class InteractableObject : MonoBehaviour, IInteractable
{
    public string InteractableName;

    [Tooltip("Index of default interaction")]
    public int defaultIndex = 0;

    protected List<Interaction> interactions = new List<Interaction>();

    //left click handling
    public void OnMouseDown(){
        //print("I am clicked: "+InteractableName);
        Interaction defaultInteraction = GetDefaultActivity();
        if(defaultInteraction != null){
            defaultInteraction.Activate();
            
        }
        

    }

    public virtual List<Interaction> GetInteractionList(){
        return interactions;
    }

    public virtual void AddInteraction(Interaction newInteraction){
        interactions.Add(newInteraction);
    }

    public Interaction GetDefaultActivity(){
        if(GetInteractionList().Count == 0){
            print("no interactions associated");
            return null;
        }
        return GetInteractionList()[defaultIndex];
    }

    public virtual string GetName(){
        if(InteractableName == null)
            InteractableName = this.gameObject.name;
        return InteractableName;
    }

    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }
}
