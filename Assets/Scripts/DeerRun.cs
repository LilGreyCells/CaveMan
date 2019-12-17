using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRun : MonoBehaviour, PlayMe
{
  public KeyFrameDeserializer keyFrameDeserializer;
  public Dictionary<string, List<Vector3>>[] keyframes;

  public FrameWork sample = new FrameWork();
  public float timeCounter;
  public float animationTime;
  private Vector3 offset = new Vector3(0, 0, 0);
  private int offsetcounter = 0;


  public int keyFramesCount;
  private float p = 0;
  public int from = 0;
  public int to = 1;
  public int keyCount = 0;
  public float u = 0;

  public float speed;
  public float animationDelay;
  bool animateStart;
  Transform movingbonetransform;
  int numberOfRuns;
  Queue<AnimationData> animations = new Queue<AnimationData>();
  public bool isTransitionAnimation;


  public void playMe(AnimationData anim)
  {
    //Need to find the closest number that evenly divides (without remainder) with the speed. 
    //This makes sure that our animation always ends in the same position = the initial keyframe position.
    //hence we only need to make one transition animation.
    //TLDR; animationtime will be increased or decreased a bit to accomodate transition animations.


    /* this.animationTime = findClosest(animationtime, speed);*/
    this.isTransitionAnimation = anim.isTransitionAnimation;
    print("transition" + anim.isTransitionAnimation);
    //instead of counting animation time, we are now gonna count the number of runs. Which is simply the animationTime/speed
    numberOfRuns = (int)(anim.animationtime / anim.speed);


    this.speed = anim.speed;
    animationDelay = anim.animationDelay;

    /**

      DO EXTRAS HERE
    */

    var extras = anim.extra;
    if (extras != null)
    {
      Debug.Log(extras);
      var exArr = extras.Split(',');
      foreach (var command in exArr)
      {
        var commandArr = command.Split(' ');
        GameObject gameObject = null;
        Moveit component = null;
        switch (commandArr[0])
        {
          case "rotate":
            gameObject = GameObject.Find(commandArr[1]);
            var floatAngle = float.Parse(commandArr[2]);
            Debug.Log(gameObject);
            component = gameObject.GetComponent<Moveit>();
            Debug.Log(component);
            component.rotate(floatAngle, float.Parse(commandArr[3]));
            // gameObject.transform.Rotate(0, 0, float.Parse(exArr[2]));
            break;
          case "detach":
            // detach from parent 
            // args object_to_be_detached force 
            gameObject = GameObject.Find(commandArr[1]);
            Vector3 localAxisForce = Vector3.zero;

            if (commandArr[4].Equals("up"))
            {
              localAxisForce = Vector3.up;
            }
            else if (commandArr[4].Equals("right"))
            {
              localAxisForce = Vector3.right;
            }
            Debug.Log(localAxisForce);
            component = gameObject.GetComponent<Moveit>();
            StartCoroutine(component.addForce(localAxisForce, float.Parse(commandArr[2]), float.Parse(commandArr[3])));
            break;
          case "translateWithoutAnimation":

            gameObject = GameObject.Find(commandArr[1]);
            float x = 0, y = 0, z = 0;
            x = float.Parse(commandArr[2]);
            y = float.Parse(commandArr[3]);
            z = float.Parse(commandArr[4]);
            gameObject.transform.Translate(new Vector3(x, y, z), Space.Self);
            // gameObject.transform.position = new Vector3(x, y, z);
            // StartCoroutine(gameObject.GetComponent<Moveit>().translate(new Vector3(x, y, z), 0, float.Parse(commandArr[5])));
            break;

          case "attach":
            // Finds the object to attach
            var attach = new AttachToPart();
            var objectToAttach = (GameObject)Resources.Load("prefabs/" + commandArr[1], typeof(GameObject));
            Debug.Log(objectToAttach + "objecttoattach");
            attach.toattach = objectToAttach;
            attach.parent = transform.Find(commandArr[3]).gameObject;

            objectToAttach = attach.attach(
              new Vector3(
                float.Parse(commandArr[4]),
                float.Parse(commandArr[5]),
                float.Parse(commandArr[6])
              ),
              float.Parse(commandArr[7])
            );
            objectToAttach.name = commandArr[2];
            objectToAttach.AddComponent<Moveit>();
            objectToAttach.GetComponent<Moveit>().addMass(float.Parse(commandArr[8]));
            objectToAttach.GetComponent<SpriteRenderer>().sortingOrder = 23;
            // Instantiate
            // sets the transform and rotation
            // args: objectName, parent, tx ty tz rz
            break;
          case "destroy":
            objectToAttach = GameObject.Find(commandArr[1]);
            Destroy(objectToAttach);
            break;
        }
      }

    }

    StartCoroutine(delayed(anim.animationDelay, anim));


    keyFrameDeserializer = new KeyFrameDeserializer();
    keyframes = keyFrameDeserializer.parseAnim(Application.dataPath + "//AnimationFiles//" + anim.animationFile);
    var enumerator = keyframes[0].Keys.GetEnumerator();
    enumerator.MoveNext();
    //keyFramesCount is actually the counting of the pairs of keyframes that need to be animated and not the number of keyframes themselves
    //if there are 8 keyframes, then there will only be 7 interpolations so to speak.
    //hence we reduce it by 1.
    keyFramesCount = (int)keyframes[0][enumerator.Current].Count - 1;
    Debug.Log(keyFramesCount);
    p = (float)(anim.speed * 1 / keyFramesCount);
  }

  public void addAnimation(bool dirRight, float animationtime, float animationDelay, string animationFile, float speed, bool isTranitionAnimation)
  {
    animations.Enqueue(new AnimationData(dirRight, animationtime, animationDelay, animationFile, speed, isTranitionAnimation));
  }

  public void addAnimation(bool dirRight, float animationtime, float animationDelay, string animationFile, float speed, bool isTranitionAnimation, string extras)
  {
    animations.Enqueue(new AnimationData(dirRight, animationtime, animationDelay, animationFile, speed, isTranitionAnimation, extras));
  }

  public void playStart()
  {
    if (animations.Count > 0)
      playMe(animations.Dequeue());
  }
  public IEnumerator delayed(float timedelay, AnimationData anim)
  {
    yield return new WaitForSeconds(timedelay);
    if (anim.dirRight == true)
      transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    animateStart = true;
  }


  // Start is called before the first frame update
  void Start()
  {
    movingbonetransform = transform.Find("bone_1");

  }
  /*
      public float findClosest(float m,float n)
      {

          int q = (int)(m / n);

          float qt = q * n;
          float qt1 = (q + 1)*n;

          if (Mathf.Abs(q - qt) < Mathf.Abs(q - qt1))
          {

              return qt; }
          else
              return qt1;


      }*/
  // Update is called once per frame
  void Update()
  {
    if (animateStart)
    {



      if (numberOfRuns > 0)
      {


        timeCounter += Time.deltaTime;

        if (timeCounter >= p * (keyCount + 1))
        {
          keyCount++;
        }
        u = sample.map(timeCounter, p * keyCount, p * (keyCount + 1));

        if (keyCount > keyFramesCount - 1)
        {

          //if keycount is 7 (out of 7) then we want it to go back, which it will by resetting the time counter.
          //First and last keyframes should be the same in rotation and position.

          //Timecounter can't be set to 0 since we need to account for the time.delta time.
          //So we simply add it to the timecounter once we reset.
          //Animation follows the same spacing.

          if (isTransitionAnimation && numberOfRuns >= 1)
          {
            transform.position = movingbonetransform.position;
            movingbonetransform.localPosition = Vector3.zero;
            timeCounter = 0;
            animateStart = false;
            keyCount = 0;
            offsetcounter = 0;
            playStart();
            return;
          }

          timeCounter = Time.deltaTime;
          numberOfRuns--;


          keyCount = 0;

          offsetcounter++;
        }


        from = keyCount;
        to = keyCount + 1;

        foreach (var bone in keyframes[0].Keys)
        {


          string[] bonearr = bone.Split('/');
          Debug.Log(bone);
          Debug.Log(bonearr);
          var bonetransform = transform.Find(bone).transform;
          float fromAngle;
          float toAngle;
          fromAngle = keyframes[0][bone][from].z;

          toAngle = keyframes[0][bone][to].z;



          var res = sample.slerp(u, fromAngle, toAngle);
          res.Normalize();
          bonetransform.localRotation = res;
        }
        foreach (var bone in keyframes[1].Keys)
        {
          var bonearr = bone.Split('/');
          var bonetransform = transform.Find(bone).transform;

          Vector3 fromVector = Vector3.zero;
          Vector3 toVector = Vector3.zero;
          if (bonearr[bonearr.Length - 1].Equals("bone_1"))
          {

            offset = (keyframes[1][bone][keyframes[1][bone].Count - 1] - keyframes[1][bone][0]) * offsetcounter;
            fromVector.Set(offset.x + keyframes[1][bone][from].x, offset.y + keyframes[1][bone][from].y, offset.z + keyframes[1][bone][from].z);
            toVector.Set(
            offset.x + keyframes[1][bone][to].x,
            offset.y + keyframes[1][bone][to].y,
            offset.z + keyframes[1][bone][to].z);
          }
          else
          {
            fromVector.Set(keyframes[1][bone][from].x, keyframes[1][bone][from].y, keyframes[1][bone][from].z);
            toVector.Set(
           keyframes[1][bone][to].x,
            keyframes[1][bone][to].y,
         keyframes[1][bone][to].z);

          }



          var res = sample.linearInterpolation(u, fromVector, toVector);
          bonetransform.localPosition = res;

        }

        Debug.Log("still here");
      }
      else
      {
        transform.position = movingbonetransform.position;
        movingbonetransform.localPosition = Vector3.zero;
        animateStart = false;
        offsetcounter = 0;
        timeCounter = 0;

        playStart();

      }

    }


  }







}
