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
    // deer.addAnimation(false, 1f, 0, "Caveman\\Walking.anim", 0.2f, false);
    // deer.addAnimation(false, 5f, 0, "Caveman\\Spear Throw Straight.anim", 2f, true);
    // deer.addAnimation(false, 5f, 0, "Caveman\\shakingFistAngry.anim", 2f, true);
    // deer.addAnimation(false, 5f, 0, "Caveman\\Spear Throw Up.anim", 2f, true);
    // deer.addAnimation(false, 2f, 0, "Caveman\\fitAnger.anim", 1f, true);

    deer.addAnimation(false, 5f, 0, "DeerGrazings.anim", 2f, false);
    deer.addAnimation(false, 5f, 0, "DeerWalking.anim", 2f, false);
    deer.addAnimation(false, 5f, 0, "DeerDeliberating.anim", 2f, false);





    deer.playStart();

  }
}