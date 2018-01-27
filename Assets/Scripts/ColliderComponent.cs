using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderComponent : MonoBehaviour {
  public Transform target;

  private MeshCollider meshCollider;
  private PathMesh pathMesh;

  private IEnumerator pathMaker() {
    while (true) {
      // Wait some time
      yield return new WaitForSeconds(0.1f);

      pathMesh.AddPoint(target.position);
      meshCollider.sharedMesh = pathMesh.mesh; // Must be done in order to rebuild collider (I think?)
    }
  }

  public void Start() {
    // Configure path mesh
    pathMesh = new PathMesh();

    // Configure collider
    meshCollider = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
    meshCollider.sharedMesh = pathMesh.mesh;

    // Configure renderer (only for DEBUG, provide MeshFilter component)
    // var meshFilter = gameObject.GetComponent<MeshFilter>();
    // meshFilter.mesh = pathMesh.mesh;

    // Start path maker
    StartCoroutine(pathMaker());
  }

  void OnCollisionEnter(Collision collision) {
    // TODO COMPLETE
    Debug.Log("Collision!");
  }

  void OnTriggerEnter(Collider collision) {
    // TODO COMPLETE
    Debug.Log("Trigger!");
  }
}
