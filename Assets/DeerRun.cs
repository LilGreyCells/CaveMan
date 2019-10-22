using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRun : MonoBehaviour,PlayMe
{
  public KeyFrameDeserializer keyFrameDeserializer;
  public Dictionary<string, List<Vector3>>[] keyframes;
  public GameObject deer;
  public FrameWork sample = new FrameWork();
  public float timeCounter;
  public float animationTime = 5;
  private Vector3 offset = new Vector3(0, 0, 0);
  private int offsetcounter = 1;
  

    public void playMe(bool flip, float animationtime)
    {
        animationTime = animationtime;
        if (flip == false)
            deer.transform.localScale =deer.transform.localScale* -1;
        timeCounter = 0;

    }

    // Start is called before the first frame update
    void Start()
  {
    keyFrameDeserializer = new KeyFrameDeserializer();
    keyframes = keyFrameDeserializer.parseAnim(Application.dataPath + "//deerRun.anim");

  }

  // Update is called once per frame
  void Update()
  {

    if (animationTime != 0)
    {
      timeCounter += Time.deltaTime;

      var currentdelta = (timeCounter * 10);

      foreach (var bone in keyframes[0].Keys)
      {



        string[] bonearr = bone.Split('/');
        var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;

        float fromAngle;
        float toAngle;
        if (currentdelta > 7)
        {
          fromAngle = keyframes[0][bone][keyframes[0][bone].Count - 1].z;
          toAngle = keyframes[0][bone][0].z;
          timeCounter = 0f;
        }
        else
        {
          fromAngle = keyframes[0][bone][(int)(Mathf.Floor(currentdelta))].z;

          toAngle = keyframes[0][bone][(int)(Mathf.Ceil(currentdelta))].z;
     

        }

        var res = sample.slerp(sample.easeinout(timeCounter),fromAngle,  toAngle);
        res.Normalize();
        bonetransform.localRotation = res;

      }


      foreach (var bone in keyframes[1].Keys)
      {
        var bonearr = bone.Split('/');
        var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;
        Vector3 fromVector = Vector3.zero;
     
        Vector3 toVector = Vector3.zero;
                
        if (currentdelta > 7)
        {

          offset = (keyframes[1][bone][keyframes[1][bone].Count - 1] -
        keyframes[1][bone][0]) * offsetcounter++;
          Debug.Log(offset);

          timeCounter = 0f;
          animationTime -= 1;

        }
        else
        {

         fromVector.Set(offset.x + keyframes[1][bone][(int)(Mathf.Floor(currentdelta))].x, offset.y + keyframes[1][bone][(int)(Mathf.Floor(currentdelta))].y, offset.z + keyframes[1][bone][(int)(Mathf.Floor(currentdelta))].z);

          toVector.Set(
          offset.x + keyframes[1][bone][(int)(Mathf.Ceil(currentdelta))].x,
          offset.y + keyframes[1][bone][(int)(Mathf.Ceil(currentdelta))].y,
          offset.z + keyframes[1][bone][(int)(Mathf.Ceil(currentdelta))].z);

          var res = sample.linearInterpolation(timeCounter, fromVector, toVector);

          bonetransform.localPosition = res;
        }


      }

    }

  }
}
