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
        deer.playMe(false, 10, 3, "deerStandingRunning.anim", 0.4f);
        yield return null;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
