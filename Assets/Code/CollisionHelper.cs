using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHelper : MonoBehaviour
{

  [HideInInspector]
  public bool collision = false;
  Collision2D foreign;

  void OnCollisionEnter2D(Collision2D foreign_) {
    collision = true;
    foreign = foreign_;
  }

  void OnCollisionExit2D(Collision2D foreign_) {
    collision = false;
  }
}