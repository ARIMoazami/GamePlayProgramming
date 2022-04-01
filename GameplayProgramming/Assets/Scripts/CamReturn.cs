using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamReturn : MonoBehaviour
{
    public GameObject newCam;
    public GameObject playerCam;
    public GameObject Player;

    public PlayerMovement Script;

    private bool exitSpline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Script.Spline = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerCam.SetActive(true);
        newCam.SetActive(false);
        Player.GetComponent<SplineMove>().enabled = false;
    }



}
