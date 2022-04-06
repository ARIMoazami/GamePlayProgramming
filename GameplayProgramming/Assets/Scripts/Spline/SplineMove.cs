using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineMove : MonoBehaviour
{
    public PlayerMovement playerspeed;
    public PlayerMovement Spline;

    public Animator PlayerAnim;

    public GameObject player;
    public PathCreator playerpath;
    private float distancetravelled;
    public bool SplineOn;

    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = playerpath.path.GetPoint(1);

        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = playerspeed.speed;

        Spline.Spline = true;

        if (Input.GetAxis("Vertical") < 0 )
        {
            distancetravelled -= speed * Time.deltaTime;
            player.transform.position = playerpath.path.GetPointAtDistance(distancetravelled, EndOfPathInstruction.Stop);
            rotation = playerpath.path.GetRotationAtDistance(distancetravelled);
            rotation.x = 0;
            rotation.z = 0;

            player.transform.rotation = rotation;

            PlayerAnim.SetBool("Backwards", true);
            PlayerAnim.SetBool("IsRunning", false);

            playerspeed.speed = 5;


        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            distancetravelled += speed * Time.deltaTime;
            player.transform.position = playerpath.path.GetPointAtDistance(distancetravelled, EndOfPathInstruction.Stop);
            rotation = playerpath.path.GetRotationAtDistance(distancetravelled);
            rotation.x = 0;
            rotation.z = 0;

            player.transform.rotation = rotation;

            PlayerAnim.SetBool("IsRunning", true);
            PlayerAnim.SetBool("Backwards", false);

            playerspeed.speed = 5;

        }
        else if(Input.GetAxis("Vertical") == 0)
        {
            
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            playerspeed.speed = 0;
            PlayerAnim.SetBool("IsRunning", false);
            PlayerAnim.SetBool("Backwards", false);
            PlayerAnim.SetBool("IsIdle", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerspeed.speed = 0;
            PlayerAnim.SetBool("IsRunning", false);
            PlayerAnim.SetBool("Backwards", false);
            PlayerAnim.SetBool("IsIdle", true);

        }

    }
}
