﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
  public DeerRun deer;
  private AttachToPart attachToPart;
  public GameObject spear;
  // Start is called before the first frame update
  void Start()
  {
    // attachToPart = GetComponent<AttachToPart>();
    /*deer.addAnimation(false, 5f, 0, "DeerRun.anim", 0.2f, false);
    deer.addAnimation(false, 1f, 0, "DeerRuntoStandingRun.anim", 1f, true);
    deer.addAnimation(true, 5f, 0, "DeerStandingRunning.anim", 0.2f, false);*/
    if (deer.gameObject.name.StartsWith("Caveman"))
    {
      deer.addAnimation(false, 3f, 0, "Caveman\\Walking.anim", 1f, false, "attach spear spear1 bone_1/bone_6/bone_7 2.81 0 0 100 10");
      deer.addAnimation(false, 0.2f, 0, "Caveman\\tWalkToLook.anim", 0.2f, true);
      deer.addAnimation(false, 5f, 0, "Caveman\\lookAndPoint.anim", 2f, true);
      deer.addAnimation(false, 1f, 0, "Caveman\\tlookToShoot.anim", 0.3f, true);
      deer.addAnimation(false, 5f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true, "rotate spear1 -90 0.5,detach spear1 20 1 right");
      deer.addAnimation(false, 2f, 0f, "Caveman\\tThrowFreeze.anim", 2f, true);
      deer.addAnimation(false, 1f, 2f, "Caveman\\tThrowToAnger.anim", 0.2f, true, "attach drop drop1 bone_1/bone_10/bone_11 0.8 0 0 -55.97 5");
      deer.addAnimation(false, 2f, 0, "Caveman\\shakingFistAngry.anim", 2f, true, "destroy drop1 0 0");
      deer.addAnimation(false, 2f, 0, "Caveman\\Spear Throw Up.anim", 0.8f, true, "attach spear spear2 bone_1/bone_6/bone_7 2.81 0 0 100 3,rotate spear2 -90 0.7,detach spear2 70 0.3 up");
      deer.addAnimation(false, 2f, 0, "Caveman\\Spear Throw Up.anim", 0.8f, true, "attach spear spear3 bone_1/bone_6/bone_7 2.81 0 0 100 3,rotate spear3 -90 0.5,detach spear3 70 0.3 up");
      deer.addAnimation(false, 2f, 0, "Caveman\\Spear Throw Up.anim", 0.8f, true, "attach spear spear4 bone_1/bone_6/bone_7 2.81 0 0 100 3,rotate spear4 -90 0.5,detach spear4 70 0.3 up");
      deer.addAnimation(false, 1.1f, 2, "Caveman\\tThrowToRunOnSpot.anim", 1.1f, true, "attach exclamation exclamation1 bone_1/bone_10/bone_11 3.11 -0.82 0 -104.3 5");
      deer.addAnimation(false, 0.7f, 0, "Caveman\\runningOnTheSpot.anim", 0.2f, false, "destroy exclamation1 0 0");
      deer.addAnimation(false, 1f, 0, "Caveman\\running.anim", 0.2f, false);
      deer.addAnimation(false, 1f, 0, "Caveman\\tRunningToNormal.anim", 0.5f, true, "attach drop drop1 bone_1/bone_10/bone_11 0.8 0 0 -55.97 5");


    }
    else if (deer.gameObject.name.StartsWith("DEER"))
    {
      // deer.addAnimation(false, 20f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);
      // deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
      // deer.addAnimation(false, 10f, 0, "DeerDeliberating.anim", 2f, false);
      // deer.addAnimation(false, 1f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);
      // deer.addAnimation(true, 5f, 0, "DeerWalking.anim", 0.2f, false);
      // deer.addAnimation(false, 2f, 0f,"DeerGrazings.anim",2f,false);
      // deer.addAnimation(false, 2f, 0, "DeerWalking.anim", 2f, false);
      // deer.addAnimation(false, 3f, 0f,"DeerGrazings.anim",2f,false);
      // deer.addAnimation(true, 4f, 0.5f,"tGrazingToAlert.anim", 3f, true, 
      // "attach question question1 bone_1/bone_2/bone_3/bone_4 9.49 2.4 0 -77.04 10");
      // deer.addAnimation(false, 1f, 0f,"tAlertToLaugh.anim",0.4f,true,"destroy question1 0 0");
      // deer.addAnimation(false,6.5f,0f,"DeerLaughing.anim",0.8f,false,
      // "attach haha haha1 BODY 8.0467 -7.28 0 0 10");
      // deer.addAnimation(false,6f,1.5f,"tlaughtoscoreready.anim",5,true,"destroy haha1 0 0");
      // deer.addAnimation(false,6f,0f,"tscorereadytoscoreshow.anim",1f,true,
      // "attach Scoreboard Scoreboard1 bone_1/bone_2/bone_7/bone_8 0.8 1 0 0 10,rotate Scoreboard1 200 1");
      // deer.addAnimation(false,2f,0f,"fshowscore.anim",1,false);
      // deer.addAnimation(false, 1f, 2f,"tshowscoretobackkickpos.anim",1f,true,"destroy Scoreboard1 0 0");
      // deer.addAnimation(true, 1f, 1f,"DBackKick.anim",0.5f,true);
    }


    /*       deer.addAnimation(false, 5f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);*/

    // deer.addAnimation(false, 5f, 0, "DCheckPyramid.anim", 1f, true);
    /*    deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
        deer.addAnimation(false, 5f, 0, "DeerDeliberating.anim", 2f, false);*/





    deer.playStart();

  }
}