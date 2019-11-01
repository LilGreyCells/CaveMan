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
    public void playMe(bool flip, float animationtime, float animationdelay, string animationFile, float speed)
    {

        //Need to find the closest number that evenly divides (without remainder) with the speed. 
        //This makes sure that our animation always ends in the same position = the initial keyframe position.
        //hence we only need to make one transition animation.
        //TLDR; animationtime will be increased or decreased a bit to accomodate transition animations.

        
        this.animationTime = findClosest(animationtime, speed);

        //instead of counting animation time, we are now gonna count the number of runs. Which is simply the animationTime/speed
        numberOfRuns =(int) (this.animationTime / speed);

        if (flip == true)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        this.speed = speed;
        animationDelay = animationdelay;
        StartCoroutine(delayed(animationdelay));

        keyFrameDeserializer = new KeyFrameDeserializer();
        keyframes = keyFrameDeserializer.parseAnim(Application.dataPath + "//AnimationFiles//" + animationFile);
        var enumerator = keyframes[0].Keys.GetEnumerator();
        enumerator.MoveNext();
        //keyFramesCount is actually the counting of the pairs of keyframes that need to be animated and not the number of keyframes themselves
        //if there are 8 keyframes, then there will only be 7 interpolations so to speak.
        //hence we reduce it by 1.
        keyFramesCount = (int)keyframes[0][enumerator.Current].Count - 1;
        Debug.Log(keyFramesCount);
        p = (float)speed * 1 / keyFramesCount;




    }
    public IEnumerator delayed(float timedelay)
    {
        yield return new WaitForSeconds(timedelay);
   
        animateStart = true;
    }


    // Start is called before the first frame update
    void Start()
    {
      

    }

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


    }
    // Update is called once per frame
    void Update()
    {
        if (animateStart)
        {
            

         
            if (numberOfRuns>0)
            {
                
               
                timeCounter += Time.deltaTime;

                if (timeCounter >= p * (keyCount + 1))
                {
                    keyCount++;
                }
                u = sample.map(timeCounter, p * keyCount, p * (keyCount + 1));

                if (keyCount > keyFramesCount - 1)
                {//if keycount is 7 (out of 7) then we want it to go back, which it will by resetting the time counter.
                    //First and last keyframes should be the same in rotation and position.
                    
                    //Timecounter can't be set to 0 since we need to account for the time.delta time.
                    //So we simply add it to the timecounter once we reset.
                    //Animation follows the same spacing. 
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
                    var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;
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
                    var bonetransform = GameObject.Find(bonearr[bonearr.Length - 1]).transform;
                    if (movingbonetransform == null && bonearr[bonearr.Length - 1].Equals("bone_1"))
                    {
                        movingbonetransform = (Transform)bonetransform;
                    }
                    Vector3 fromVector = Vector3.zero;
                    Vector3 toVector = Vector3.zero;
                    offset = (keyframes[1][bone][keyframes[1][bone].Count - 1] - keyframes[1][bone][0]) * offsetcounter;
                    fromVector.Set(offset.x + keyframes[1][bone][from].x, offset.y + keyframes[1][bone][from].y, offset.z + keyframes[1][bone][from].z);
                    toVector.Set(
                    offset.x + keyframes[1][bone][to].x,
                    offset.y + keyframes[1][bone][to].y,
                    offset.z + keyframes[1][bone][to].z);

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
               
            }
           
        }


    }

  
}
