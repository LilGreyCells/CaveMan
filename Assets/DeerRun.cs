using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRun : MonoBehaviour
{
  public KeyFrameDeserializer keyFrameDeserializer;
  public Dictionary<string, List<Vector3>> keyframes;
  public GameObject deer;
  public FrameWork sample = new FrameWork();
  public float timeCounter;
  public float animationTime = 5;
  public float rotationMax = 150f;

  // Start is called before the first frame update
  void Start()
  {
    keyFrameDeserializer = new KeyFrameDeserializer();
    keyframes = keyFrameDeserializer.parseAnim("sss");

    timeCounter = 0;
  }

  // Update is called once per frame
  void Update()
  {

    if (animationTime != 0)
    {
      timeCounter += Time.deltaTime;
      // Debug.Log(timeCounter);
      var u = sample.map(timeCounter, Mathf.Floor(timeCounter * 10), Mathf.Ceil(timeCounter * 10));


      foreach (var bone in keyframes.Keys)
      {
        var currentdelta = (timeCounter * 10);

        Debug.Log(currentdelta);
        string[] bonearr = bone.Split('/');
        var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;
        // Debug.Log(currentdelta);

        float fromAngle;
        float toAngle;
        if (currentdelta > 9)
        {
          fromAngle = keyframes[bone][keyframes[bone].Count - 1].z;
          toAngle = keyframes[bone][0].z;
          timeCounter = 0.22f;
        }
        else
        {
          fromAngle = keyframes[bone][(int)(Mathf.Floor(currentdelta))].z;
          toAngle = keyframes[bone][(int)(Mathf.Ceil(currentdelta))].z;

        }

        Debug.Log(fromAngle + "=>>>" + toAngle);
        var res = sample.slerp(sample.easeinout(timeCounter), new Data(0, 0, 0, 0, 0, 0, 1, fromAngle), new Data(0, 0, 0, 0, 0, 0, 1, toAngle));
        res.Normalize();
        bonetransform.localRotation = res;
        // var finalrotation = bonetransform.rotation.ToAxisAngle();

        // Debug.Log(bonetransform.rotation)
      }

      if (timeCounter > 1)
      {
        timeCounter = 0;
        animationTime -= 1;
      }
    }

  }
}
