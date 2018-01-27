using UnityEngine;
using System.Collections;

public class EventManager {
  public delegate void CollisionAction(Collision collision, GameObject gameObject);

  public static event CollisionAction OnCollisionAction;

  public static void CallOnCollisionAction(Collision collision, GameObject gameObject) {
    OnCollisionAction(collision, gameObject);
  }
}
