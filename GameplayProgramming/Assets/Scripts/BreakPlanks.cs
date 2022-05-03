using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlanks : MonoBehaviour
{
    public GameObject plank1;
    public GameObject plank2;
    public GameObject plank3;
    public GameObject plank4;

    private bool canBreak = false;

    private int plankNum = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canBreak)
        {
            if(Input.GetButtonDown("Attack"))
            {
                plankNum -= 1;
            }
        }

        if(plankNum == 3)
        {
            plank1.SetActive(false);
        }

        if (plankNum == 2)
        {
            plank2.SetActive(false);
        }

        if (plankNum == 1)
        {
            plank3.SetActive(false);
        }

        if (plankNum == 0)
        {
            plank4.SetActive(false);
        }
    }

     void OnTriggerEnter(Collider other)
    {
        canBreak = true;
    }

    void OnTriggerExit(Collider other)
    {
        canBreak = false;
    }
}
