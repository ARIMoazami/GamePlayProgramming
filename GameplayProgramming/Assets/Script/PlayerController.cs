using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator Anim;

    private bool canJump;

    //public CharacterController controller;


    public float moveSpeed = 5f;
    public float turnSpeed = 50f;
    public float jumpHeight = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("IsRunning", true);
            transform.position += Time.deltaTime * moveSpeed * transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
            transform.position += Time.deltaTime * moveSpeed * -transform.right;

        if (Input.GetKey(KeyCode.S))
            transform.position += Time.deltaTime * moveSpeed * -transform.forward;

        if (Input.GetKey(KeyCode.D))
            transform.position += Time.deltaTime * moveSpeed * transform.right;

        //jumping
        if (canJump == false)
            canJump = Input.GetButtonDown("Jump");


        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.down);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);


        //testing
        

    }

    private void FixedUpdate()
    {
        if(canJump)
        {
            rigidBody.AddForce(jumpHeight * Vector3.up);
            canJump = false;
       }
    }
}
