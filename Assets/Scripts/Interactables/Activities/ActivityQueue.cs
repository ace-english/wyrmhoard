using System;
using UnityEngine;
using AceDevelopment.Shared.AceUtil;


public class ActivityQueue : AceQueue<Activity>
{ 

    public delegate void QueueChangedCallback();
    public QueueChangedCallback queueChangedCallback;
    public GameObject AssociatedEntity;

    public static ActivityQueue DefaultActivityQueue;

    public ActivityQueue() : base()
    {

    }

    public ActivityQueue(GameObject AssociatedEntity) : base()
    {
        this.AssociatedEntity = AssociatedEntity;
    }

    public override void Enqueue(Activity item)
    {
        base.Enqueue(item);
        item.expireCallback += Remove;
        Debug.Log("Enqueueing " + item.ActivityName + ". Queue: " + Display());
        //add listener
        if (queueChangedCallback != null)
        {
            queueChangedCallback.Invoke();
        }

    }

    public override void InsertAt(int index, Activity item)
    {
        base.InsertAt(index, item);
        if (queueChangedCallback != null)
        {
            queueChangedCallback.Invoke();
        }
    }

    public override void Remove(Activity item)
    {
        base.Remove(item);
        Debug.Log("Removing " + item.ActivityName + ". Queue: " + Display() + " Count: " + Count);
        if (queueChangedCallback != null)
        {
            queueChangedCallback.Invoke();
        }
    }

    public override void Remove(int index)
    {
        base.Remove(index);
        Debug.Log("Removing " + index + ". Queue: " + Display());
        if (queueChangedCallback != null)
        {
            queueChangedCallback.Invoke();
        }
    }
}
