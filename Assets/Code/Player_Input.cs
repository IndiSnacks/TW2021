using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public float move_speed = 500;
    public float dash_speed = 60000;
    public Rigidbody2D player_rb;

    Vector2 movement_direction;
    bool dash_movment;

    //getting player input
    void Update() 
    {
        //gets the up down left righ input
       movement_direction.x = Input.GetAxisRaw("Horizontal");
       movement_direction.y = Input.GetAxisRaw("Vertical");
    }

    //Moving the player 
    void FixedUpdate() 
    {
        //moves the player around the screen
        player_rb.velocity =  new Vector2(movement_direction.x, movement_direction.y) * move_speed * Time.deltaTime;
    }
}
