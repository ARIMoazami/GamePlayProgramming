using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorButton : MonoBehaviour
{
    public GameObject MainUIText;
    public GameObject cutsceneCAM;
    public GameObject playerCAM;

    public GameObject Player;

    public Animator doorAnim;

    private bool MainDoorOpen = false;
    private Animator buttonAnim;


    // Start is called before the first frame update
    void Start()
    {

        cutsceneCAM.SetActive(false);

        MainUIText.SetActive(false);


    }

    private bool InOverlap
    {
        get
        {
            return MainUIText.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (InOverlap && !MainDoorOpen && Input.GetButtonDown("Interact"))
        {
            cutsceneCAM.SetActive(true);
            playerCAM.SetActive(false);
            StartCoroutine(Opening());

            Player.GetComponent<PlayerMovement>().enabled = false;
        }

        if (MainDoorOpen)
        {
            MainUIText.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
        }

    }

    IEnumerator camReturn()
    {
        yield return new WaitForSeconds(1);
        cutsceneCAM.SetActive(false);
        playerCAM.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    IEnumerator Opening()
    {
        yield return new WaitForSeconds(1);
        doorAnim.Play("DoorOpen");
        MainDoorOpen = true;
        StartCoroutine(camReturn());
    }



    private void OnTriggerEnter(Collider other)
    {
        MainUIText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        MainUIText.SetActive(false);
    }
}