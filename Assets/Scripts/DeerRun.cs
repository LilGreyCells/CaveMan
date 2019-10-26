using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRun : MonoBehaviour, PlayMe
{
    public KeyFrameDeserializer keyFrameDeserializer;
    public Dictionary<string, List<Vector3>>[] keyframes;
    public GameObject deer;
    public FrameWork sample = new FrameWork();
    public float timeCounter;
    public float animationTime;
    private Vector3 offset = new Vector3(0, 0, 0);
    private int offsetcounter = 0;

    private int totalTime = 1;

    public int keyFramesCount;
    private float p = 0;
    public int from = 0;
    public int to = 1;
    public int keyCount = 0;
    public float u = 0;

    public float speed;
    public float animationDelay;
    bool animateStart;
    string animationFile;
    Transform movingbonetransform;
    public void playMe(bool flip, float animationtime, float animationdelay, string animationFile, float speed)
    {
        this.animationTime = animationtime;
        if (flip == true)
            deer.transform.localScale = deer.transform.localScale * -1;
        this.animationFile = animationFile;
        this.speed = speed;
        StartCoroutine(delayed(animationdelay));




    }
    public IEnumerator delayed(float timedelay)
    {
        yield return new WaitForSeconds(timedelay);

        animateStart = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        keyFrameDeserializer = new KeyFrameDeserializer();
        keyframes = keyFrameDeserializer.parseAnim(Application.dataPath + "//AnimationFiles//" + animationFile);
        var enumerator = keyframes[0].Keys.GetEnumerator();
        enumerator.MoveNext();
        keyFramesCount = (int)keyframes[0][enumerator.Current].Count;
        p = (float)speed * 1 / keyFramesCount;

    }

    // Update is called once per frame
    void Update()
    {
        if (animateStart)
        {
            if (animationTime != 0)
            {
                timeCounter += Time.deltaTime;

                if (timeCounter >= p * (keyCount + 1))
                {
                    keyCount++;
                }
                u = sample.map(timeCounter, p * keyCount, p * (keyCount + 1));

                if (keyCount >= keyFramesCount - 1)
                {
                    timeCounter = 0f;
                    keyCount = 0;
                    animationTime -= 1;
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
            }
            else
            {
                deer.transform.position = movingbonetransform.position;
                animateStart = false;
               
            }
           
        }


    }
}
