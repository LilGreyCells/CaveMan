using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    public DeerRun deer;
    // Start is called before the first frame update
    void Start()
    {
        deer.addAnimation(false, 5f, 0, "deerRun.anim", 0.5f, false);
        deer.addAnimation(false, 1f, 0, "DeerRuntoStandRun.anim", 1f, true);
        deer.addAnimation(false, 5f, 0, "deerStandingRunning.anim", 0.5f,false);



       
        deer.playStart();

    }
}