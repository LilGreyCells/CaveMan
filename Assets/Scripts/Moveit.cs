using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveit : MonoBehaviour
{
  private FrameWork frameWork;
  private float playtimeRotation, playtimeTranslation, fromrotation, torotation, angle, time, mass;

  private Vector3 linearMomentum, force, velocity, distance;

  private bool isPhysics, translating, rotating;

  private Vector3 fromTranslation;

  private Vector3 toTranslation;
  // Start is called before the first frame update
  void Start()
  {
    frameWork = new FrameWork();
  }

  // Update is called once per frame
  void Update()
  {
    if (rotating)
    {
      time += Time.deltaTime;
      float u = frameWork.map(time, 0, playtimeRotation);
      var rotation = frameWork.slerp(u, fromrotation, torotation);
      rotation.Normalize();
      Debug.Log("U of spear " + u);
      transform.localRotation = rotation;
      // transform.rotation = rotation;
      // playtimeRotation -= Time.deltaTime;

      if (u >= 1f)
      {
        rotating = false;
      }
    }
    Debug.Log("Rotation of sphere" + transform.localRotation.eulerAngles.z);

    if (translating)
    {
      time += Time.deltaTime;
      float u = frameWork.map(time, 0, playtimeTranslation);
      if (float.IsInfinity(u))
        u = 1;
      var newPosition = frameWork.linearInterpolation(u, fromTranslation, toTranslation);
      transform.position = newPosition;
      playtimeTranslation -= Time.deltaTime;

      if (playtimeTranslation < 0f || u == 1)
      {
        translating = false;
      }
    }


    if (isPhysics)
    {
      force = Vector3.down * 9.8f;

      distance += velocity * Time.deltaTime;
      transform.position = distance;
      linearMomentum += force * Time.deltaTime;
      velocity = linearMomentum / mass;

      var plane = GameObject.Find("Plane");
      if (Mathf.Abs(plane.transform.position.y - transform.position.y) <= 0.3f)
      {
        Debug.Log("Zhalla");
        distance = Vector3.zero;
        velocity = Vector3.zero;
        linearMomentum = Vector3.zero;
        force = Vector3.zero;
        isPhysics = false;

      }
    }
  }
  public void rotate(float angle, float playtime)
  {
    rotating = true;
    this.playtimeRotation = playtime;
    this.fromrotation = transform.localRotation.eulerAngles.z;
    this.torotation = angle;

    Debug.Log("fromRotation " + fromrotation);
    Debug.Log("toRotation " + torotation);
    time = 0;
  }

  public void translate(Vector3 toPosition, float playtime)
  {
    translating = true;
    fromTranslation = transform.position;
    toTranslation = toPosition;
    this.playtimeTranslation = playtime;
    time = 0;
  }

  public IEnumerator translate(Vector3 toPosition, float playtime, float delay)
  {
    yield return new WaitForSeconds(delay);

    translating = true;
    fromTranslation = transform.position;
    toTranslation = toPosition;
    this.playtimeTranslation = playtime;
    time = 0;
  }

  public IEnumerator addForce(Vector3 direction, float amplitude, float delay)
  {
    if (delay != 0)
    {
      yield return new WaitForSeconds(delay);
    }
    distance = transform.position;
    transform.parent = null;
    Debug.Log("Force is with you");
    isPhysics = true;
    linearMomentum = direction * amplitude;
    // yield return new WaitForSeconds(0.7f);
    // rotate(-10, 1);
  }

  public void addMass(float mass)
  {
    this.mass = mass;
  }
}
