using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingThings : MonoBehaviour
{

    private Vector2 startPosition;
    private Vector2 newPosition;

    //Bool variable if user wants to Move enemy Horizotally only
    public bool moveHorizontally = false;

    //Bool variable if user wants to Move enemy Vertically only
    public bool moveVertically = false;

    //Speed of Enemy Movement in Directions
    public int speed = 3;

    //Maximum Distance Enemy can travel while moving in Loop
    public int maxDistance = 1;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        //If MoveHorizontally is set to true then Update Enemy Postion in Horizontal (forward and backward) Direction Only
        if(moveHorizontally)
        {
            newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
        }

        //If MoveVertically is set to true then Update Enemy Postion in Vertical (upward and downward) Direction Only
        if (moveVertically)
        {
            newPosition.y = startPosition.y + (maxDistance * Mathf.Sin(Time.time * speed));
        }
        
        if(moveHorizontally||moveVertically)
        {
            transform.position = newPosition;
        }
        
    }
}
