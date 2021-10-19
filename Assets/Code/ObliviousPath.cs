using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObliviousPath : MonoBehaviour
{
    public Vector3[] path;
    public LineRenderer renderer;
    public float arcPiece;

    int size;

    void Start() {
      size = path.Length;
    }

    void Update() {
      for(int i = 0; i < size; i++) {
        drawArc((Vector2)path[i], 0, 2*Mathf.PI, 1.0f);
      }
    }

    void drawArc(Vector2 pos, float angle0, float angle1, float radius) {

      float angle = angle1 - angle0;
      int segments = (int)(radius * angle / arcPiece) + 1;

      float posAngle = angle0;

      renderer.positionCount = segments;

      for(int i = 0; i < segments; i++) {

        float x = radius * Mathf.Cos(posAngle);
        float y = radius * Mathf.Sin(posAngle);

        renderer.SetPosition(i, new Vector3(x, y, 0));

        posAngle += arcPiece / radius;
      }
    }
}
