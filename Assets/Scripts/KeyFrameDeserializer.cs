using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Order { }
public class KeyFrameDeserializer
{
  public string file;
  private Dictionary<string, List<Vector3>> keyframesRotation = new Dictionary<string, List<Vector3>>();

  private Dictionary<string, List<Vector3>> keyframesTranslation = new Dictionary<string, List<Vector3>>();


  // Start is called before the first frame update
  public  Dictionary<string, List<Vector3>>[] parseAnim(string animfile)
  {
    bool isPosition = false;
        using (StreamReader sr = new StreamReader(animfile))
        {
            var line = "";
            List<Vector3> keyframelist = new List<Vector3>();
            while (!((line = sr.ReadLine()).Equals("  m_ScaleCurves: []")))
            {
                // Debug.Log(line);
                if (line.Trim().StartsWith("value"))
                {

                    string[] vector = line.Trim().Substring(7).Replace("{", "").Replace("}", "").Split(',');
                    keyframelist.Add(new Vector3(
                    float.Parse(vector[0].Substring(3)),
                    float.Parse(vector[1].Substring(3)),
                    float.Parse(vector[2].Substring(3))));
                }
                if (line.Trim().StartsWith("path"))
                {
                    if (isPosition)
                    {
                        try
                        {
                            keyframesTranslation.Add(line.Trim().Substring(6).ToString(), keyframelist);
                        }
                        catch(Exception e)
                        {
                            Debug.Log(line);
                        }
                    }
                    else
                    {
                        keyframesRotation.Add(line.Trim().Substring(6).ToString(), keyframelist);
                    }
                    // keyframelist.Clear();
                    keyframelist = new List<Vector3>();
                }
                if (line.Equals("  m_PositionCurves:"))
                {
                    isPosition = true;
                }
            }
            return new Dictionary<string, List<Vector3>>[] { keyframesRotation, keyframesTranslation };
        }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
