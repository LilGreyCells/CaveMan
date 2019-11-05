using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    public DeerRun deer;
    // Start is called before the first frame update
    void Start()
    {
        deer.addAnimation(false, 10, 3, "deerStandingRunning.anim", 0.2f);



        deer.addAnimation(false, 10, 0, "deerRun.anim", 2f);
        deer.playStart();

    }
}