using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginFight : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject aiScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Enemy.GetComponent<EnemyPatrol>().enabled = false;
            //aiScript.GetComponent<AICombat>().enabled = true;

            Enemy.GetComponent<AICombat>().Chase = true;
            Enemy.GetComponent<AICombat>().Patrol = false;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Enemy.GetComponent<EnemyPatrol>().enabled = true;
            //aiScript.GetComponent<AICombat>().enabled = false;

            Enemy.GetComponent<AICombat>().Chase = false;
            Enemy.GetComponent<AICombat>().Patrol = true;
        }
            
    }
}
