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
      GameObject camera = GameObject.Find("MainCamera");
      camera.AddComponent<Moveit>();
      // GameObject spear = GameObject.Find("spear");
      // attachToPart.toattach = spear;
      // attachToPart.parent = deer.gameObject.transform.Find("bone_1/bone_6/bone_7").gameObject;
      // var insSpear = attachToPart.attach(new Vector3(2.81f, 0, 0), 100);
      // insSpear.AddComponent<Moveit>()
      // insSpear.AddComponent<Moveit>();
      // insSpear.GetComponent<Moveit>().addMass(10);
      deer.addAnimation(false, 3f, 0, "Caveman\\Walking.anim", 1f, false, "attach spear spear1 bone_1/bone_6/bone_7 2.81 0 0 100 10");
      deer.addAnimation(false, 0.2f, 0, "Caveman\\tWalkToLook.anim", 0.2f, true);
      deer.addAnimation(false, 5f, 0, "Caveman\\lookAndPoint.anim", 2f, true);
      deer.addAnimation(false, 1f, 0, "Caveman\\tlookToShoot.anim", 0.3f, true);
      deer.addAnimation(false, 5f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true, "rotate spear1 -90 0.5,detach spear1 20 1");
      deer.addAnimation(false, 2f, 0f, "Caveman\\tThrowFreeze.anim", 2f, true);
      deer.addAnimation(false, 1f, 2f, "Caveman\\tThrowToAnger.anim", 1f, true, "translateWithoutAnimation MainCamera 0 -4.87 -6.8 0,attach drop drop1 bone_1/bone_10/bone_11 0.8 0 0 -55.97 5");
      deer.addAnimation(false, 2f, 3, "Caveman\\shakingFistAngry.anim", 2f, true, "translateWithoutAnimation MainCamera 0 -5.31 -11.1 2.5,destroy drop1 0 0");
      deer.addAnimation(false, 3f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true, "attach spear spear2 bone_1/bone_6/bone_7 2.81 0 0 100 10,rotate spear2 -90 0.5,detach spear2 40 1");
      deer.addAnimation(false, 3f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true, "attach spear spear3 bone_1/bone_6/bone_7 2.81 0 0 100 10,rotate spear3 -90 0.5,detach spear3 50 1");
      deer.addAnimation(false, 3f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true, "attach spear spear4 bone_1/bone_6/bone_7 2.81 0 0 100 10,rotate spear4 -90 0.5,detach spear4 60 1");


    }
    else if (deer.gameObject.name.StartsWith("DEER"))
    {
      // deer.addAnimation(false, 20f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);
      // deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
      deer.addAnimation(false, 10f, 0, "DeerDeliberating.anim", 2f, false);
      deer.addAnimation(false, 1f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);
      deer.addAnimation(true, 5f, 0, "DeerWalking.anim", 0.2f, false);

    }


    /*       deer.addAnimation(false, 5f, 0, "DeerRunningOnTheSpot.anim", 0.2f, false);*/

    // deer.addAnimation(false, 5f, 0, "DCheckPyramid.anim", 1f, true);
    /*    deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
        deer.addAnimation(false, 5f, 0, "DeerDeliberating.anim", 2f, false);*/





    deer.playStart();

  }
}