using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginFight : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject halfSlime;
    public GameObject miniSlime;

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
            Enemy.GetComponent<AICombat>().Chase = true;
            Enemy.GetComponent<AICombat>().Patrol = false;

            halfSlime.GetComponent<AICombat>().Chase = true;
            halfSlime.GetComponent<AICombat>().Patrol = false;

            miniSlime.GetComponent<AICombat>().Chase = true;
            miniSlime.GetComponent<AICombat>().Patrol = false;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Enemy.GetComponent<AICombat>().Chase = false;
            Enemy.GetComponent<AICombat>().Patrol = true;

            halfSlime.GetComponent<AICombat>().Chase = false;
            halfSlime.GetComponent<AICombat>().Patrol = true;

            miniSlime.GetComponent<AICombat>().Chase = false;
            miniSlime.GetComponent<AICombat>().Patrol = true;
        }

            
    }
}
