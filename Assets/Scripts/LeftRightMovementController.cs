using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovementController : MonoBehaviour
{
    //Transform Position of PointA where enemy can Petrol
    public Transform PointA;

    //Transform Position of PointB where enemy can Petrol
    public Transform PointB;

    //Speed of Enemy Petrolling
    public float speed = 0.1f;

    //Bool which returns in which direction enemy is Facing
    bool m_FacingRight = false;

    private void Start()
    {
        //Start coroutine that Move enemy from Point A to Point B in a Loop
        StartCoroutine("MoveToPoint");
    }

    IEnumerator MoveToPoint()
    {
        while (true)
        {
            Flip();
            while (true)
            {
                //Move Enemy to Point A
                transform.position = Vector3.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);

                if (transform.position == PointA.position)
                {
                    break;
                }

                yield return null;
            }

            Flip();
            while (true)
            {
                //Move Enemy to Point B
                transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);

                if (transform.position == PointB.position)
                {
                    break;
                }

                yield return null;
            }

            yield return null;
        }
        
    }
   
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
