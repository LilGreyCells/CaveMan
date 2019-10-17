using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRun : MonoBehaviour
{
  public KeyFrameDeserializer keyFrameDeserializer;
  public Dictionary<string, List<Vector3>>[] keyframes;
  public GameObject deer;
  public FrameWork sample = new FrameWork();
  public float timeCounter;
  public float animationTime = 5;
  public float rotationMax = 150f;
  private Vector3 offset = new Vector3(0, 0, 0);
  private int offsetcounter = 1;

  // Start is called before the first frame update
  void Start()
  {
    keyFrameDeserializer = new KeyFrameDeserializer();
    keyframes = keyFrameDeserializer.parseAnim("sss");
    foreach (var i in keyframes[1].Keys)
    {
      foreach (var j in keyframes[1][i])
      {
        Debug.Log(j.y);
      }
    }

    timeCounter = 0;
  }

  // Update is called once per frame
  void Update()
  {

    if (animationTime != 0)
    {
      timeCounter += Time.deltaTime;
      // Debug.Log(timeCounter);
      // var u = sample.map(timeCounter, Mathf.Floor(timeCounter * 10), Mathf.Ceil(timeCounter * 10));
      var currentdelta = (timeCounter * 10);

      foreach (var bone in keyframes[0].Keys)
      {


        // Debug.Log(currentdelta);
        string[] bonearr = bone.Split('/');
        var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;
        // Debug.Log(currentdelta);

        float fromAngle;
        float toAngle;
        if (currentdelta > 8)
        {
          fromAngle = keyframes[0][bone][keyframes[0][bone].Count - 1].z;
          toAngle = keyframes[0][bone][0].z;
          timeCounter = 0.22f;
        }
        else
        {
          fromAngle = keyframes[0][bone][(int)(Mathf.Floor(currentdelta))].z;
          // try
          // {
          toAngle = keyframes[0][bone][(int)(Mathf.Ceil(currentdelta))].z;
          // }
          // catch (System.Exception)
          // {
          //   toAngle = 0;
          //   Debug.Log("current deltaaa: " + currentdelta);
          // }

        }

        //  Debug.Log(fromAngle + "=>>>" + toAngle);
        var res = sample.slerp(sample.easeinout(timeCounter), new Data(0, 0, 0, 0, 0, 0, 1, fromAngle), new Data(0, 0, 0, 0, 0, 0, 1, toAngle));
        res.Normalize();
        bonetransform.localRotation = res;
        // var finalrotation = bonetransform.rotation.ToAxisAngle();

        // Debug.Log(bonetransform.rotation)
      }


      foreach (var bone in keyframes[1].Keys)
      {
        var bonearr = bone.Split('/');
        var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;
        Data fromVector = null;
        Data toVector = null;
        if (currentdelta > 8)
        {

          offset = (keyframes[1][bone][keyframes[1][bone].Count - 1] -
        keyframes[1][bone][0]) * offsetcounter++;
          Debug.Log(offset);

          // fromVector = new Data(0,
          // offset.x + keyframes[1][bone][keyframes[1][bone].Count - 1].x,
          // keyframes[1][bone][keyframes[1][bone].Count - 1].y,
          // offset.z + keyframes[1][bone][keyframes[1][bone].Count - 1].z, 0, 0, 0, 0);
          // toVector = new Data(0,
          // offset.x + keyframes[1][bone][0].x,
          // keyframes[1][bone][0].y,
          // offset.z + keyframes[1][bone][0].z, 0, 0, 0, 0);
          timeCounter = 0.22f;
          animationTime -= 1;

        }
        else
        {
          fromVector = new Data(0,
          offset.x + keyframes[1][bone][(int)(Mathf.Floor(currentdelta))].x,
          offset.y + keyframes[1][bone][(int)(Mathf.Floor(currentdelta))].y,
          offset.z + keyframes[1][bone][(int)(Mathf.Floor(currentdelta))].z, 0, 0, 0, 0);
          toVector = new Data(0,
          offset.x + keyframes[1][bone][(int)(Mathf.Ceil(currentdelta))].x,
          offset.y + keyframes[1][bone][(int)(Mathf.Ceil(currentdelta))].y,
          offset.z + keyframes[1][bone][(int)(Mathf.Ceil(currentdelta))].z, 0, 0, 0, 0);

          var res = sample.linearInterpolation(timeCounter, fromVector, toVector);

          bonetransform.localPosition = res;
        }


      }

    }

  }
}
