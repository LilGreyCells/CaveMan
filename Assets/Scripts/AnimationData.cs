using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationData 
{
    public bool dirRight;
    public float animationtime;
    public float animationDelay;
    public string animationFile;
    public float speed;
    public bool isTransitionAnimation;

   public AnimationData (bool dirRight, float animationtime, float animationDelay, string animationFile, float speed, bool transitionAnimation)
    {
        this.dirRight = dirRight;
        this.animationtime = animationtime;
        this.animationDelay = animationDelay;
        this.animationFile = animationFile;
        this.speed = speed;
        this.isTransitionAnimation = transitionAnimation;
    }
}
