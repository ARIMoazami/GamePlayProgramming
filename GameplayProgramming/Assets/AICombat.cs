using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICombat : MonoBehaviour
{

    public Transform FollowTarget;
    NavMeshAgent navMesh;


    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(FollowTarget.position);
    }
}
