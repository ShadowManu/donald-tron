using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathMesh {
  static float HEIGHT = 5;

  public Mesh mesh = new Mesh();

  public List<Vector3> path = new List<Vector3>();
  public List<Vector3> vertices = new List<Vector3>();

  public void AddPoint(Vector3 point) {
    // If its the first point
    if (path.Count == 0) {
      path.Add(point);
      return;
    }

    var start = path[path.Count - 1];
    var end = point;

    path.Add(point);

    // Vertices of first triangle
    AddVertex(start, 0); // Floor1
    AddVertex(end, 0); // Floor2
    AddVertex(start, HEIGHT); // Ceiling

    // Vertices of second triangle
    AddVertex(end, 0); // Floor
    AddVertex(start, HEIGHT); // Ceiling1
    AddVertex(end, HEIGHT); // Ceiling2

    UpdateMesh();
  }

  private void AddVertex(Vector3 point, float height) {
    vertices.Add(new Vector3(point.x, height, point.z));
  }

  private void UpdateMesh() {
    mesh.vertices = vertices.ToArray();
    mesh.triangles = Enumerable.Range(0, vertices.Count).ToArray();
  }

}
