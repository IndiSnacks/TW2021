using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHelper : MonoBehaviour
{

  [HideInInspector]
  public bool collision = false;
  Collision2D foreign;

  private void OnCollisionEnter2D(Collision2D foreign_) {
    Debug.Log("COLLIDING");
    collision = true;
    foreign = foreign_;
  }

  private void OnCollisionExit2D(Collision2D foreign_) {
    collision = false;
  }
}
