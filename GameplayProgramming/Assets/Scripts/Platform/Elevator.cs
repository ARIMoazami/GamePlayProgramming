using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator PlatformAnim;
    // Update is called once per frame
    void Update()
    {
     
    }


    private void OnTriggerEnter(Collider other)
    {
        PlatformAnim.Play("Elevator");

    }

    private void OnTriggerExit(Collider other)
    {
        PlatformAnim.Play("ElevatorDown");

    }
}
