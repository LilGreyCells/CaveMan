using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
   public DeerRun deer;
    // Start is called before the first frame update
    void Start()
    {
        deer.playMe(true, 7, 3, "deerRun.anim",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
