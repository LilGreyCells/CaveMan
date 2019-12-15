using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPart : MonoBehaviour
{
    public GameObject toattach;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    public void attach(Vector3 position,bool ifrot)
    {
        toattach.transform.parent = parent.transform;
        toattach.transform.localPosition = position;
        if (ifrot)
        {
            toattach.transform.Rotate(new Vector3(0, 0, 1), 45);
        }
        
    }

    // Update is called once per frame
    
}
