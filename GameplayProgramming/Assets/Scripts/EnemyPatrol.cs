using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Transform[] patrolWaypoints;

    public int speed;

    private int waypointIndex;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(patrolWaypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, patrolWaypoints[waypointIndex].position);
        if(distance < 5f)
        {
            Index();
        }
        BeginPatrol();
    }

    void BeginPatrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Index()
    {
        waypointIndex++;
        if(waypointIndex >= patrolWaypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(patrolWaypoints[waypointIndex].position);
    }
}
