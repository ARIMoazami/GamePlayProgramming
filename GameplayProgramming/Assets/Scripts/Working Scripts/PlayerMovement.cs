using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private float moveX;
    private float moveY;

    public CharacterController controller;
    public Transform cam;
    public TrailRenderer TrailEffect;
    public GameObject ParticleEffect;

    Animator Anim;
    PlayerControls controls;

    Vector2 move;

    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float speedBoostTimer = 3;
    private bool speedBoost = false;
    private bool doublejump = false;

    public float ySpeed;

    Vector3 motion;
    Vector3 moveDir;
    public float gravity;
    public float yDirection;
    public float jumpNo;

    //jumping
    private float JumpCount = 1;
    private float doublejumpTimer = 4;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        controls.Enable();

        controls.Player.DefaultActionRoll.performed += Roll;

        controls.Player.CombatAction.performed += Attack;

        controls.Player.DefaultActionInteract.performed += Interact;

    }
    void Start()
    {

    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 moveVector = movementValue.Get<Vector2>();

        moveX = moveVector.x;
        moveY = moveVector.y;

    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(moveX, 0f, moveY);
        controller.SimpleMove(Vector3.forward * 0);

        if(controller.isGrounded)
        {
            yDirection = 0f;
            jumpNo = 0;
            Anim.SetBool("IsJumping", false);
            Anim.SetBool("HasLanded", true);
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            motion = direction * speed * Time.deltaTime;

            Anim.SetBool("IsRunning", true);
            Anim.SetBool("IsIdle", false);
        }
        else
        {
            direction = new Vector3(0f, 0f, 0f);
            motion = direction * speed * Time.deltaTime;

            Anim.SetBool("IsRunning", false);
            Anim.SetBool("IsIdle", true);
        }

        Vector3 velocity = Vector3.forward * 0;
        velocity.y = ySpeed;
        controller.Move(velocity * Time.deltaTime);

        if(speedBoost)
        {
            speed = 15;
            speedBoostTimer -= Time.deltaTime;
            TrailEffect.emitting = true;
            if(speedBoostTimer <= 0)
            {
                speed = 5;
                speedBoost = false;
                speedBoostTimer = 3;
                TrailEffect.emitting = false;
            }
        }

        if (doublejump)
        {
            JumpCount = 2;
            doublejumpTimer -= Time.deltaTime;
            ParticleEffect.SetActive(true);
            if (doublejumpTimer <= 0)
            {
                JumpCount = 1;
                doublejumpTimer = 4;
                doublejump = false;
                ParticleEffect.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Jump") && jumpNo < JumpCount)
        {
            yDirection = ySpeed;
            jumpNo += 1;
            Anim.SetBool("IsJumping", true);
        }


        yDirection -= gravity * Time.deltaTime;
        motion.y = yDirection;
        controller.Move(motion);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUpsSpeed")
        {
            speedBoost = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "PowerUpsJump")
        {
            doublejump = true;
            Destroy(other.gameObject);
        }
    }

    void Roll(InputAction.CallbackContext context)
    {
        Anim.SetTrigger("Dodge");
    }

    void Attack(InputAction.CallbackContext context)
    {
        Anim.SetTrigger("Attack");
    }

    void Interact(InputAction.CallbackContext context)
    {
        Anim.SetTrigger("Interact");
    }
}
