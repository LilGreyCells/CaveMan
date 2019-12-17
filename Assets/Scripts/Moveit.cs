using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveit : MonoBehaviour
{
  private FrameWork frameWork;
  private float playtimeRotation, playtimeTranslation, fromrotation, torotation, angle, time, mass;

  private Vector3 linearMomentum, force, velocity, distance;

  private bool isPhysics, translating, rotating, isGoingDown;

  private Vector3 fromTranslation;
  private Vector3 initialForceDirection;
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
      transform.localRotation = rotation;
      // transform.rotation = rotation;
      // playtimeRotation -= Time.deltaTime;

      if (u >= 1f)
      {
        rotating = false;
      }
    }

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
      force = Vector3.down * 9.8f * mass;
      if (name.Equals("first") || name.Equals("second") || name.Equals("third") || name.Equals("fourth"))
      {
        mass = 1;
        force = Vector3.zero;
      }
      distance += velocity * Time.deltaTime;
      transform.position = distance;
      linearMomentum += force * Time.deltaTime;
      velocity = linearMomentum / mass;
      if ((velocity / velocity.magnitude) == Vector3.down && !isGoingDown)
      {
        isGoingDown = true;
        if (initialForceDirection == Vector3.right)
        {
          rotate(90, 2);
        }
        else if (initialForceDirection == Vector3.up)
        {
          Debug.Log("Start rotating");
          rotate(-90, 0.5f);
        }
      }
      var plane = GameObject.Find("Plane");
      if (Mathf.Abs(plane.transform.position.y - transform.position.y) <= 0.3f)
      {
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
    initialForceDirection = direction;
    isGoingDown = false;
    distance = transform.position;
    transform.parent = null;
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
