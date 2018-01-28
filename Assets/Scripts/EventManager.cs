using UnityEngine;
using System.Collections;

public class EventManager {
    public delegate void CollisionAction(GameObject collide, GameObject gameObject);

    public static event CollisionAction OnCollisionAction;

    public static void CallOnCollisionAction(GameObject collide, GameObject gameObject)
    {
        OnCollisionAction(collide, gameObject);
    }

    public delegate void WinnerAction(string winner);

    public static event WinnerAction OnWinnerAction;

    public static void CallOnWinnerAction(string winner)
    {
        OnWinnerAction(winner);
    }
}
