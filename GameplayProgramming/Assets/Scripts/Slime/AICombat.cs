using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICombat : MonoBehaviour
{

    public Transform[] wayPoints;
    int currentIndex;

    Vector3 followTarget;

    public Transform Player;

    NavMeshAgent navMesh;

    public float speed;

    public float Health;

    public bool Chase = false;

    public bool Patrol = true;

    private float dist;


    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        navMesh.SetDestination(wayPoints[currentIndex].position);
    }

    void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Chase)
        {
            navMesh.SetDestination(Player.position);
        }
        else if(Patrol)
        {
            navMesh.SetDestination(wayPoints[currentIndex].position);
            if(navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                IncreaseIndex();
            }
            

        }
    }

    void IncreaseIndex()
    {
        currentIndex = (currentIndex + 1) % wayPoints.Length;
        navMesh.SetDestination(wayPoints[currentIndex].position);
    }
}
