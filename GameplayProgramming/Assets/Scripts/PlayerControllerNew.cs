using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerNew : MonoBehaviour
{
    PlayerControls controls;
    Rigidbody rb;
    Animator Anim;

    Vector2 move;

    private bool isGrounded = true;

    public float speed = 10f;


    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();

        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        controls.Enable();
        controls.Player.Jump.performed += Jump;

        controls.Player.CombatAction.performed += Roll;
    }

    void SendMessage(Vector2 coordinates)
    {
        Debug.Log("Thumb-stick coords = " + coordinates);
    }

    void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    void Roll(InputAction.CallbackContext context)
    {
        Anim.SetBool("IsDiving", true);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);



    }
}
