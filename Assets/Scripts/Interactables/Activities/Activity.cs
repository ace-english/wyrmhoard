using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;


    public class Activity
    {

        //should include a dropdown for modes, like running/walking
        //action may have subroutines, like -walk to, start animation, channel animation, exit animation

        //hypothetically serializable

        //every action is potentiall an action queue
        //clicking on one action to cancel cancels the whole queue - probably shouldn't though. holding a drink?

        //should be click and draggable

        public Texture2D sprite;

        public string ActivityName { get; }
        public string animation { get; set; }
        bool toExpire = false;
        public bool cancelable = true;
        public AnimationClip animationClip { get; internal set; }

        public Activity Next;

        // expire callback - fires when action is done

        public delegate void ExpireCallback(Activity action);
        public ExpireCallback expireCallback;

        public Activity()
        {

        }

        public virtual void Update()
        {
            ;
        }

        public virtual void Expire()
        {
            if (expireCallback != null)
            {
                expireCallback.Invoke(this);
            }
        }

        public virtual string Display()
        {
            return "Activity Name: " + ActivityName;

        }

    }
