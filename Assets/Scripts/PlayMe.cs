using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayMe
{
  void playMe(AnimationData anim);
    IEnumerator delayed(float timedelay);


    void addAnimation(bool dirRight, float animationtime, float animationDelay, string animationFile, float speed);

    void playStart();
}
