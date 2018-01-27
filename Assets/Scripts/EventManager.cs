using UnityEngine;
using System.Collections;

public class EventManager {
  public delegate void CollisionAction(Collision collision);

  public static event CollisionAction OnCollisionAction;

  public static void CallOnCollisionAction(Collision collision) {
    OnCollisionAction(collision);
  }
}
