using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public abstract class HumanoidEntity : MobileEntity {

    private Transform leftKnee, rightKnee, rightHip, leftHip;

    void Awake()
    {
        leftKnee = transform.Find("Knee_L");
        rightKnee = transform.Find("Knee_R");
        rightHip = transform.Find("Hip_R");
        leftHip = transform.Find("Hip_L");
    }
    public void Crouch(){
        //step a little
        //lower waist
    }

}
