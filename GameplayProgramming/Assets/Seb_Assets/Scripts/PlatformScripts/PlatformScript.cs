using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    [Header("Allow platform to move")]
    public bool MovingPlatform = true;

    [Header("X Positions to move to")]
    [Range(0.0f, 10.0f)]
    [Tooltip("This distance is based off the left of the starting position of the platform")]
    public float pointA_xpos = 2f;
    [Range(0.0f, 10.0f)]
    [Tooltip("This distance is based off the right of the starting position of the platform")]
    public float pointB_xpos = 2f;

    [Header("Y Positions to move to")]
    [Range(0.0f, 10.0f)]
    [Tooltip("This distance is based off the left of the starting position of the platform")]
    public float pointA_ypos = 2f;
    [Range(0.0f, 10.0f)]
    [Tooltip("This distance is based off the right of the starting position of the platform")]
    public float pointB_ypos = 2f;

    [Header("Z Positions to move to")]
    [Range(0.0f, 10.0f)]
    [Tooltip("This distance is based off the left of the starting position of the platform")]
    public float pointA_zpos = 2f;
    [Range(0.0f, 10.0f)]
    [Tooltip("This distance is based off the right of the starting position of the platform")]
    public float pointB_zpos = 2f;

    [Header("Speed of the platform when moving")]
    [Range(0.0f, 4.0f)]
    public float speed = 2f;

    private Vector3 targetPositionA;
    private Vector3 targetPositionB;

    private bool reachedA = false;
    private bool reachedB = false;

    void Start()
    {
        pointA_xpos = transform.position.x - pointA_xpos;
        pointB_xpos = transform.position.x + pointB_xpos;

        pointA_ypos = transform.position.y - pointA_ypos;
        pointB_ypos = transform.position.y + pointB_ypos;

        pointA_zpos = transform.position.z - pointA_zpos;
        pointB_zpos = transform.position.z + pointB_zpos;

        targetPositionA = new Vector3(pointA_xpos, pointA_ypos, pointA_zpos);
        targetPositionB = new Vector3(pointB_xpos, pointB_ypos, pointB_zpos);



    }

    void Update()
    {

        if (MovingPlatform)
        {
            float step = speed * Time.deltaTime;

            if (reachedA)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPositionB, step);

                if (checkIfReached(targetPositionB))
                {
                    reachedA = false;
                    reachedB = true;
                }
            }
            else if (reachedB)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPositionA, step);

                if (checkIfReached(targetPositionA))
                {
                    reachedB = false;
                    reachedA = true;
                }
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPositionA, step);

                if (checkIfReached(targetPositionA))
                {

                    reachedA = true;
                }

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Transform player = collision.collider.gameObject.transform;
            Debug.Log("Entered Platform collide");

            player.parent = this.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Transform player = collision.collider.gameObject.transform;
            Debug.Log("Left platform collide");

            player.parent = null;
        }
    }

    bool checkIfReached(Vector3 targetPosition)
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            return true;
        }
        else
        {
            return false;
        }


    }


}
