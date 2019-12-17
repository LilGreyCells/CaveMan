using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayMe
{
  void playMe(AnimationData anim);
    IEnumerator delayed(float timedelay,AnimationData anim);


    void addAnimation(bool dirRight, float animationtime, float animationDelay, string animationFile, float speed,bool isTransitionAnimation);

    void playStart();
}
