using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
   public DeerRun deer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(animateScene());

    }
    public IEnumerator animateScene()
    {
        deer.playMe(false, 10, 3, "deerStandingRunning.anim", 0.2f);

        yield return new WaitForSeconds(13);

        deer.playMe(false, 10, 0, "deerRun.anim", 2f);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
