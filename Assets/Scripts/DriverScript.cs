using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    public DeerRun deer;
    // Start is called before the first frame update
    void Start()
    {
        /*deer.addAnimation(false, 5f, 0, "DeerRun.anim", 0.2f, false);
        deer.addAnimation(false, 1f, 0, "DeerRuntoStandingRun.anim", 1f, true);
        deer.addAnimation(true, 5f, 0, "DeerStandingRunning.anim", 0.2f, false);*/

       /* deer.addAnimation(false, 5f, 0, "DeerGrazings.anim", 2f, false);
        deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);*/
        deer.addAnimation(false, 10f, 0, "DeerLaughing.anim", 1f, false);




        deer.playStart();

    }
}