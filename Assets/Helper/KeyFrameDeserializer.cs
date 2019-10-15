using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Order { }
public class KeyFrameDeserializer
{
  public string file;
  private Dictionary<string, List<Vector3>> keyframes = new Dictionary<string, List<Vector3>>();

  // Start is called before the first frame update
  public Dictionary<string, List<Vector3>> parseAnim(string animfile)
  {
    using (StreamReader sr = new StreamReader("C:\\Users\\Dishant Kaushik\\CaveMan\\Assets\\deerRun.anim"))
    {
      var line = "";
      List<Vector3> keyframelist = new List<Vector3>();
      while (!((line = sr.ReadLine()).Equals("  m_PositionCurves: []")))
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
          keyframes.Add(line.Trim().Substring(6).ToString(), keyframelist);
          // keyframelist.Clear();
          keyframelist = new List<Vector3>();
        }
      }
      return keyframes;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
