using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private bool allowDMG = false;

    public GameObject Slime;
    public GameObject NextSlime;

    private float SlimeHealth;

    private bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        SlimeHealth = Slime.GetComponent<AICombat>().Health;

        print(SlimeHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(allowDMG)
        {
            if(Input.GetButtonDown("Attack"))
            {
               SlimeHealth -= 1;
               print(SlimeHealth);
            }
        }

        if(SlimeHealth == 0)
        {

            death = true;
        }

        if(death)
        {
            death = false;
            StartCoroutine(SplitSlime());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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

    IEnumerator SplitSlime()
    {
        yield return new WaitForSeconds(0.5F);
        GameObject duplicate = Instantiate(NextSlime, Slime.transform.position, Quaternion.identity);
        Instantiate(NextSlime, Slime.transform.position, Quaternion.identity);
        Destroy(Slime);
    }
}
