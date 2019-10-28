using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayMe
{
  void playMe(bool dirRight,float animationtime, float animationDelay,string animationFile, float speed);
    IEnumerator delayed(float timedelay);
    float findClosest(float m, float n);
}
