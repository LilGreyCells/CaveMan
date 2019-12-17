using System.Collections;
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
      deer.addAnimation(false, 1f, 0, "Caveman\\tRunningToNormal.anim", 0.5f, true, "attach anger anger1 bone_1/bone_10/bone_11 1.55 -0.05 0 0 5");
      deer.addAnimation(false, 2f, 3, "Caveman\\fitAnger.anim", 2f, true);
      deer.addAnimation(false, 2f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true, "attach spear spear5 bone_1/bone_6/bone_7 2.81 0 0 100 5,rotate spear5 -90 0.5,detach spear5 20 1 right,destroy anger1 0 0");

      deer.addAnimation(false, 15f, 5, "Caveman\\runningFast.anim", 0.4f, false);

      // --------------------------------------------------
      // SCENE CHANGE
      // --------------------------------------------------

      // deer.addAnimation(false, 5f, 0, "Caveman\\runningFast.anim", 0.4f, false);

      // --------------------------------------------------
      // SCENE CHANGE
      // --------------------------------------------------

      // deer.addAnimation(false, 3f, 0, "Caveman\\runningFast.anim", 0.2f, false);
      // deer.addAnimation(true, 3f, 3, "Caveman\\Walking.anim", 0.6f, false);
      // deer.addAnimation(false, 3f, 0, "Caveman\\Walking.anim", 0.6f, false, "translateWithoutAnimation Caveman_1 -5 0 0 0");
      // deer.addAnimation(false, 0.2f, 0, "Caveman\\tWalkingToThinking.anim", 0.2f, true);
      // deer.addAnimation(false, 2f, 0, "Caveman\\thinking.anim", 2f, true, "attach exclamation exclamation1 bone_1/bone_10/bone_11 3.11 -0.82 0 -104.3 5");
      // deer.addAnimation(true, 0.2f, 0, "Caveman\\tThinkingToLook.anim", 0.2f, true);
      // deer.addAnimation(false, 1f, 0, "Caveman\\lookAndPoint.anim", 1f, true, "destroy exclamation1 0 0,attach anger anger1 bone_1/bone_10/bone_11 1.55 -0.05 0 0 5");
      // deer.addAnimation(false, 4, 0, "Caveman\\lookingUp.anim", 4, true);
      // deer.addAnimation(false, 4, 4, "Caveman\\lookingDown.anim", 4, true);
      // deer.addAnimation(false, 2f, 0, "Caveman\\fitAnger.anim", 2f, true);
      // deer.addAnimation(false, 3f, 0, "Caveman\\runningFast.anim", 0.2f, false);


      // --------------------------------------------------
      // SCENE CHANGE
      // --------------------------------------------------
      // deer.addAnimation(false, 5f, 0, "Caveman\\runningFast.anim", 0.2f, false);

      // --------------------------------------------------
      // SCENE CHANGE
      // --------------------------------------------------

      // deer.addAnimation(false, 1, 0, "Caveman\\goUp.anim", 1, false);
      // deer.addAnimation(false, 1, 0, "Caveman\\goDown.anim", 1, false);
      // deer.addAnimation(false, 1, 0, "Caveman\\goUp.anim", 1, false, "translateWithoutAnimation Caveman_1 6.86 -0.7 0 0");
      // deer.addAnimation(false, 1, 0, "Caveman\\goDown.anim", 1, false);
      // deer.addAnimation(false, 1, 0, "Caveman\\goUp.anim", 1, false, "translateWithoutAnimation Caveman_1 -7.86 3 0 0");
      // deer.addAnimation(false, 1, 0, "Caveman\\goDown.anim", 1, false);

    }
    else if (deer.gameObject.name.StartsWith("DEER"))
    {
      // deer.addAnimation(false, 20f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);
      // deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
      // deer.addAnimation(false, 10f, 0, "DeerDeliberating.anim", 2f, false);
      // deer.addAnimation(false, 1f, 0, "DeerRunningOnTheSpot.anim", 0.2f, true);
      // deer.addAnimation(true, 5f, 0, "DeerWalking.anim", 1f, false);



      // --------------------------------------------------
      // SCENE CHANGE
      // --------------------------------------------------

      // deer.addAnimation(false, 1, 0, "Caveman\\goUp.anim", 1, false);
      // deer.addAnimation(false, 1, 0, "Caveman\\goDown.anim", 1, false);
      // deer.addAnimation(false, 1, 0, "Caveman\\goUp.anim", 1, false, "translateWithoutAnimation Caveman_1 -6.86 -0.7 0 0");
      // deer.addAnimation(false, 1, 0, "Caveman\\goDown.anim", 1, false);
      // deer.addAnimation(false, 1, 0, "Caveman\\goUp.anim", 1, false, "translateWithoutAnimation Caveman_1 7.86 3 0 0");
      // deer.addAnimation(false, 1, 0, "Caveman\\goDown.anim", 1, false);
    }


    /*       deer.addAnimation(false, 5f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);*/

    // deer.addAnimation(false, 5f, 0, "DCheckPyramid.anim", 1f, true);
    /*    deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
        deer.addAnimation(false, 5f, 0, "DeerDeliberating.anim", 2f, false);*/





    deer.playStart();

  }
}