using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformButton : MonoBehaviour
{
    private bool Overlap = false;

    public Material Red;
    public Material Green;

    public bool On = true;

    public GameObject Button;

    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    private bool InOverlap
    {
        get
        {
            return Overlap;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InOverlap && !On && Input.GetButtonDown("Interact"))
        {
            platform1.transform.GetComponent<FollowMultiple>().speed = 0;
            platform2.transform.GetComponent<FollowMultiple>().speed = 0;
            platform3.transform.GetComponent<FollowMultiple>().speed = 0;
            platform4.transform.GetComponent<FollowMultiple>().speed = 0;
            Button.GetComponent<MeshRenderer>().material = Red;
            On = true;

        }
        else if (InOverlap && On && Input.GetButtonDown("Interact"))
        {
            platform1.transform.GetComponent<FollowMultiple>().speed = 5;
            platform2.transform.GetComponent<FollowMultiple>().speed = 5;
            platform3.transform.GetComponent<FollowMultiple>().speed = 5;
            platform4.transform.GetComponent<FollowMultiple>().speed = 5;
            Button.GetComponent<MeshRenderer>().material = Green;
            On = false;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Overlap = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Overlap = false;
    }
}
