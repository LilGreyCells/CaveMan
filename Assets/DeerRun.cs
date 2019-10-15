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
      Debug.Log(timeCounter);
      var u = sample.map(timeCounter, Mathf.Floor(timeCounter), Mathf.Ceil(timeCounter));


      foreach (var bone in keyframes.Keys)
      {
        var currentdelta = timeCounter * 10 / keyframes[bone].Count;
        var res = sample.slerp(u, new Data(0, 0, 0, 0, 0, 0, 1, keyframes[bone][(int)(Mathf.Floor(currentdelta))].z), new Data(0, 0, 0, 0, 0, 0, 1, keyframes[bone][(int)(Mathf.Ceil(currentdelta))].z));
        if (deer == null)
          Debug.Log("not");
        var bonetransform = GameObject.Find(bone).transform;
        bonetransform.SetPositionAndRotation(bonetransform.position, res);
      }

      if (timeCounter > 1)
      {
        timeCounter = 0;
        animationTime -= 1;
      }
    }

  }
}
