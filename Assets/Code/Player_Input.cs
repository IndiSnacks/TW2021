using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    const float sqrt2 = 1.414f;

    public float max_speed;
    public float move_friction;
    public float dash_speed;
    public Transform transform;

    Vector2 movement_direction;
    Vector2 velocity;

    bool dash;

    public GameObject field;
    public Transform fieldBox;

    public CollisionHelper ch;
    private bool colliding;

    void Start() {

      colliding = false;
      fieldBox = field.GetComponent<Transform>();
    }

    //getting player input
    void Update()
    {
        //gets the up down left right input
       movement_direction.x = Input.GetAxisRaw("Horizontal");
       movement_direction.y = Input.GetAxisRaw("Vertical");

       float sqrMag = movement_direction.sqrMagnitude;
       if(sqrMag > 1) {
         movement_direction /= sqrt2;
       }

       movement_direction *= max_speed;

       if(!colliding && ch.collision) {
         Debug.Log("Colliding");
       }
       colliding = ch.collision;
    }

    //Moving the player
    void FixedUpdate()
    {
        //moves the player around the screen
        Vector2 diff = movement_direction - velocity;
        velocity += move_friction * diff * Time.fixedDeltaTime;

        if(!dash && Input.GetKeyDown("space")) {
          velocity += dash_speed * movement_direction;
        }
        dash = Input.GetKeyDown("space");

        transform.Translate(velocity * Time.fixedDeltaTime);

        Vector2 position = transform.position;
        float x = position[0];
        float y = position[1];

        float fieldRight = fieldBox.localScale[0] / 2;
        float fieldTop = fieldBox.localScale[1] / 2;

        if(x < -fieldRight) position[0] = -fieldRight;
        if(x > fieldRight)  position[0] = fieldRight;

        if(y < -fieldTop) position[1] = -fieldTop;
        if(y > fieldTop)  position[1] = fieldTop;

        transform.position = position;
    }
}
