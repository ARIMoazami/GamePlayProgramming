using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject newCam;
    public GameObject playerCam;

    private bool camSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camSwitch)
        {
            playerCam.SetActive(false);
            newCam.SetActive(true);
        }

        if(!camSwitch)
        {
            playerCam.SetActive(true);
            newCam.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        camSwitch = true;
    }



}
