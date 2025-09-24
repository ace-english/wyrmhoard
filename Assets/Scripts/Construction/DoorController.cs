using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : InteractableObject
{
    bool isLocked, isEntrance, isOpen;

    void Awake()
    {
        InteractableName = "Door";
        isLocked = false;
        isEntrance = false;
        isOpen = false;

        interactions = new List<Interaction>
        {
            new UnlockDoorInteraction(this),
            new LockDoorInteraction(this),
            new SetDoorAsEntranceInteraction(this)
        };
    }
    public bool IsLocked() { return isLocked; }
    public bool IsEntrance() { return isEntrance; }
    public bool IsOpen() { return isOpen; }

    public void OpenDoor()
    {
        //if unlocked,
        //run animation
    }
    public void CloseDoor()
    {
        //run animation
    }

    public void LockDoor()
    {
        isLocked = true;
    }
    public void UnlockDoor()
    {
        isLocked = false;
    }
    public void SetAsEntrance()
    {
        if (GameObject.Find("DungeonRoot").GetComponent<DungeonRoot>().SetEntrance(this))
        {
            isEntrance = true;
        }
    }
}

internal class SetDoorAsEntranceInteraction : Interaction
{
    public SetDoorAsEntranceInteraction(InteractableObject associatedInteractable) : base(associatedInteractable)
    {
    }

    public override bool IsActivatable()
    {
        if ((AssociatedInteractable as DoorController).IsEntrance())
            return false;
        return true;
    }
    

    public override void Activate(){
        (AssociatedInteractable as DoorController).SetAsEntrance();
    }
}


internal class UnlockDoorInteraction : Interaction
{
    public UnlockDoorInteraction(InteractableObject associatedInteractable) : base(associatedInteractable)
    {
    }

    public override bool IsActivatable()
    {
        if ((AssociatedInteractable as DoorController).IsLocked())
            return true;
        return false;
    }
    

    public override void Activate(){
        (AssociatedInteractable as DoorController).UnlockDoor();
    }
}

internal class LockDoorInteraction : Interaction
{
    public LockDoorInteraction(InteractableObject associatedInteractable) : base(associatedInteractable)
    {
    }

    public override bool IsActivatable()
    {
        if ((AssociatedInteractable as DoorController).IsLocked())
            return false;
        return true;
    }
    

    public override void Activate(){
        (AssociatedInteractable as DoorController).LockDoor();
    }
}
