using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
