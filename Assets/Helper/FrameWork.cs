using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Data
{
  public readonly float x, y, z;
  public readonly float i, j, k;
  public float axisangle;
  public float time;

  public Data(float time, float x, float y, float z, float i, float j, float k, float axisangle)
  {
    this.x = x;
    this.y = y;
    this.z = z;
    this.time = time;
    this.i = i;
    this.j = j;
    this.k = k;
    this.axisangle = axisangle;

    //  Debug.Log("time " + time + " x " + x);
  }

}
public class FrameWork
{
  private float elapsedTime = 0.0f;
  public TextAsset input;
  private List<Data> moveData = new List<Data>();
  private Matrix4x4 transformMe;

  public float map(float t, float t1, float t2)
  {
    //simple mapping
    return (t - t1) / (t2 - t1);
  }
  public float easeinout(float u)
  {
    return (Mathf.Sin((float)(u * Math.PI - Math.PI / 2)) + 1) / 2;
  }

  public Vector3 linearInterpolation(float u, Data data1, Data data2)
  {

    return new Vector3((data2.x - data1.x) * u + data1.x, (data2.y - data1.y) * u + data1.y, (data2.z - data1.z) * u + data1.z);
  }

  public Vector3 catmullrom(float u, Data prev, Data curr, Data curr1, Data curr2)
  {
    Matrix4x4 MCR = new Matrix4x4(new Vector4(-1, 2, -1, 0) * 0.5f,
        new Vector4(3, -5, 0, 2) * 0.5f,
        new Vector4(-3, 4, 1, 0) * 0.5f,
        new Vector4(1, -1, 0, 0) * 0.5f);

    Matrix4x4 G = new Matrix4x4(new Vector4(prev.x, prev.y, prev.z), new Vector4(curr.x, curr.y, curr.z), new Vector4(curr1.x, curr1.y, curr1.z), new Vector4(curr2.x, curr2.y, curr2.z));
    Matrix4x4 MCRG = MCR * G.transpose;
    Vector4 result = MCRG.transpose * new Vector4(u * u * u, u * u, u, 1);
    Debug.Log(result);
    return new Vector3(result.x, result.y, result.z);


  }
  public Quaternion slerp(float u, Data data1, Data data2)
  {
    //
    // Debug.Log((float)(Math.PI / 180) * data1.axisangle);
    // Debug.Log(data2);
    Quaternion q1 = Quaternion.AngleAxis(data1.axisangle, new Vector3(data1.i, data1.j, data1.k));
    Quaternion q2 = Quaternion.AngleAxis(data2.axisangle, new Vector3(data2.i, data2.j, data2.k));
    float theta = Mathf.Acos(Quaternion.Dot(q1, q2));
    if (theta == 0)
      return q1;
    Quaternion q = new Quaternion();
    float a = Mathf.Sin((1 - u) * theta) / Mathf.Sin(theta);
    float b = Mathf.Sin(u * theta) / Mathf.Sin(theta);
    q.Set(q1.x * a + q2.x * b, q1.y * a + q2.y * b, q1.z * a + q2.z * b, q1.w * a + q2.w * b);


    //Debug.Log(q);

    return q;


  }
  public void format(string data)
  {
    String[] lines = data.Split('\n');

    for (int i = 0; i < lines.Length; i++)
    {
      String[] record = lines[i].Split(' ');
      moveData.Add(new Data
         (float.Parse(record[0].ToString()),
          float.Parse(record[1].ToString()),
          float.Parse(record[2].ToString()),
          float.Parse(record[3].ToString()),
          float.Parse(record[4].ToString()),
          float.Parse(record[5].ToString()),
          float.Parse(record[6].ToString()),
          float.Parse(record[7].ToString())));

    }

  }



  // Start is called before the first frame update
  // void Start()
  // {
  //     format(input.text);




  // }


  // Update is called once per frame
  // void Update()
  // {
  //     elapsedTime += Time.deltaTime;
  //     float t1 = Mathf.Floor(elapsedTime);
  //     float t2 = Mathf.Ceil(elapsedTime);
  //     if (elapsedTime < 9)
  //     {   //t to u mapping
  //         float u = map(elapsedTime, t1, t2);
  //           u = easeinout(u);
  //         //linear interpolation
  //         // Vector3 position = linearInterpolation(u, moveData[(int)t1], moveData[(int)t2]);
  //         int prevtime = 0,currtime=0,curr1time=0,curr2time=0;

  //         prevtime = (int)t1-1;
  //         currtime = (int)t1;
  //         curr1time = (int)(t2);
  //         curr2time = ((int)(t2 + 1));

  //             if (t1 - 1 < 0)
  //         { prevtime = 0; }
  //             if(t2>9 || t2+1>9)
  //         { curr1time = 9;
  //             curr2time = 9;
  //         }
  //         Vector3 position = catmullrom(u, moveData[prevtime], moveData[currtime], moveData[curr1time], moveData[curr2time]);
  //         //rotational interpolation
  //         Quaternion q = slerp(u,moveData[(int)t1] , moveData[(int)t2]);
  //         q.Normalize();
  //         //apply coordinates
  //         //Debug.Log(position);
  //         transform.SetPositionAndRotation(position,q);

  //     }



  // }
}
