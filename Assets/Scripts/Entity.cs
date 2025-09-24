using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Entity : InteractableObject
{
    public string entityName;

    public Activity currentActivity;

    public ActivityQueue activityQueue = new ActivityQueue();

}
