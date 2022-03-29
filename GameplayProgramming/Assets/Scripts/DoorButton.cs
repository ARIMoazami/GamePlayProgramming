using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject UIText;
    public GameObject cutsceneCAM;
    public GameObject playerCAM;

    public GameObject Player;

    public Animator doorAnim;

    private bool DoorOpen = false;
    private Animator buttonAnim;


    // Start is called before the first frame update
    void Start()
    {
        buttonAnim = GetComponent<Animator>();

        cutsceneCAM.SetActive(false);

        UIText.SetActive(false);

       
    }

    private bool InOverlap
    {
        get
        {
            return UIText.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (InOverlap && !DoorOpen && Input.GetButtonDown("Interact"))
        {
            buttonAnim.SetTrigger("Pressed");
            cutsceneCAM.SetActive(true);
            playerCAM.SetActive(false);
            StartCoroutine(Opening());

            Player.GetComponent<PlayerMovement>().enabled = false;
        }
        else if (InOverlap && DoorOpen && Input.GetButtonDown("Interact"))
        {
            buttonAnim.SetTrigger("Pressed");
            cutsceneCAM.SetActive(true);
            playerCAM.SetActive(false);
            StartCoroutine(Closing());

            Player.GetComponent<PlayerMovement>().enabled = false;
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
        DoorOpen = true;
        StartCoroutine(camReturn());
    }

    IEnumerator Closing()
    {
        yield return new WaitForSeconds(1);
        doorAnim.Play("DoorClose");
        DoorOpen = false;
        StartCoroutine(camReturn());
    }


    

    private void OnTriggerEnter(Collider other)
    {
        UIText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UIText.SetActive(false);
    }
}
