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


    public GameObject playerCam;
    public GameObject lockOnCam;

    public GameObject jumpPowerUp;
    public Transform powerupLocation;

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
    private float doublejumpTimer = 20;

    private bool EnemyLock = false;

    public bool Spline = false;

    //Collectable
     /// Coin
    private int coin_count = 0;
    //Powerups
    /// StrongAttack
    public bool strong_attack_enabled = false;

    //Destructible
    private bool near_destructible = false;
    private GameObject destructible_object;

    public int hasEssence = 0;


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

        Vector3 direction = new Vector3(moveX, 0f, moveY).normalized;
        //controller.SimpleMove(Vector3.forward * 0);

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
            if(!Spline)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //motion = direction * speed * Time.deltaTime;

            Anim.SetBool("IsRunning", true);
            Anim.SetBool("IsIdle", false);

           
        }
        else
        {
            direction = new Vector3(0f, 0f, 0f);
            motion = direction * speed * Time.deltaTime;

            Anim.SetBool("IsRunning", false);
            Anim.SetBool("IsIdle", true);
            Anim.SetBool("Backwards", false);
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
                doublejumpTimer = 20;
                doublejump = false;
                ParticleEffect.SetActive(false);
                Instantiate(jumpPowerUp, powerupLocation);
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

        if(Input.GetButtonDown("LockOn") && !EnemyLock)
        {
            playerCam.SetActive(false);
            lockOnCam.SetActive(true);
            EnemyLock = true;
        }
        else if(EnemyLock && Input.GetButtonDown("LockOn"))
        {
            playerCam.SetActive(true);
            lockOnCam.SetActive(false);
            EnemyLock = false;
        }

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

        if (other.tag == "Destructible")

        {
            near_destructible = true;
            destructible_object = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Destructible")
        {
            near_destructible = false;
        }
    }

    void Roll(InputAction.CallbackContext context)
    {
        Anim.SetTrigger("Dodge");
    }

    void Attack(InputAction.CallbackContext context)
    {
        Anim.SetTrigger("Attack");

        if (strong_attack_enabled && near_destructible)
        {
            //~0.8f to match attack animation finish
            StartCoroutine(DestroyDestructible(0.8f));
        }

    }

    

    void Interact(InputAction.CallbackContext context)
    {
        Anim.SetTrigger("Interact");

        if (strong_attack_enabled && near_destructible)
        {
            //~0.8f to match attack animation finish
            StartCoroutine(DestroyDestructible(0.8f));
        }
    }
    IEnumerator DestroyDestructible(float duration_to_wait)
    {
        yield return new WaitForSeconds(duration_to_wait);
        Destroy(destructible_object);
        destructible_object = null;
    }

    public int getCoins()
    {
        return coin_count;
    }

    public void setCoins(int coins)
    {
        coin_count = coins;
    }

    public bool getStrongAttack()
    {
        return strong_attack_enabled;
    }

    public void setStrongAttack(bool strong_attack_bool)
    {
        strong_attack_enabled = strong_attack_bool;
        Debug.Log("strong attack is: " + strong_attack_enabled);
    }



}
