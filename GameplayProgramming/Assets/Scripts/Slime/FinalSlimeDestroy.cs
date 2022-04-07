using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSlimeDestroy : MonoBehaviour
{
    private bool allowDMG = false;

    public GameObject Slime;

    private GameObject originalSlime;

    private float SlimeHealth;

    private bool death = false;

    public Healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        SlimeHealth = Slime.GetComponent<AICombat>().Health;

        healthbar.BaseHealth(SlimeHealth);
    }

    void Awake()
    {
        originalSlime = GameObject.FindWithTag("Slime");
    }

    // Update is called once per frame
    void Update()
    {

        if (allowDMG)
        {
            if (Input.GetButtonDown("Attack"))
            {
                SlimeHealth -= 1;
                healthbar.Health(SlimeHealth);
            }
        }

        if (SlimeHealth == 0)
        {

            death = true;
        }

        if (death)
        {
            Destroy(Slime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            allowDMG = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            allowDMG = false;
        }
    }
}
