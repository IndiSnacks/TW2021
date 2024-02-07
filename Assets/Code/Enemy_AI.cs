using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    public float speed;
    public ObliviousPath path;

    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      Vector2 velocity = new Vector2();

      velocity.y = -speed * Time.fixedDeltaTime;

      transform.Translate(velocity);
    }
}
