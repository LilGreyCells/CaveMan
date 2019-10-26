using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
   public DeerRun deer;
    // Start is called before the first frame update
    void Start()
    {
        deer.playMe(false, 15, 3, "deerRun.anim",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
