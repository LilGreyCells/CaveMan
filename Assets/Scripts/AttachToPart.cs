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
  public GameObject attach(Vector3 position, float rotation)
  {
    toattach = Instantiate(toattach, parent.transform);
    // toattach.transform.parent = parent.transform;
    toattach.transform.localPosition = position;
    toattach.transform.Rotate(0, 0, rotation, Space.Self);
    return toattach;
  }

  public void rotate(float rotation)
  {
    toattach.transform.Rotate(0, 0, rotation);
  }

  // Update is called once per frame

}