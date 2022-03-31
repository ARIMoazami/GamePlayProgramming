using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follow : MonoBehaviour
{
    public PathCreator createPath;
    public float speed = 5;
    float distTravelled;
    public EndOfPathInstruction endOfPathInstruction;

    public GameObject Player;

    void Start()
    {
        if (createPath != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            createPath.pathUpdated += OnPathChanged;
        }
    }
    void Update()
    {
        if(createPath != null)
        {
            distTravelled += speed * Time.deltaTime;
            transform.position = createPath.path.GetPointAtDistance(distTravelled);
            transform.rotation = createPath.path.GetRotationAtDistance(distTravelled);
        }
        

    }

    void OnPathChanged()
    {
        distTravelled = createPath.path.GetClosestDistanceAlongPath(transform.position);
    }
}
