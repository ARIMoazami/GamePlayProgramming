using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject UIText;
    public GameObject cutsceneCAM;
    public GameObject playerCAM;

    public Animator doorAnim;

    private bool DoorOpen = false;
    private bool TimerOn = false;
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
            doorAnim.Play("DoorOpen");
            DoorOpen = true;
            StartCoroutine(camReturn());
        }
        else if (InOverlap && DoorOpen && Input.GetButtonDown("Interact"))
        {
            buttonAnim.SetTrigger("Pressed");
            cutsceneCAM.SetActive(true);
            playerCAM.SetActive(false);
            doorAnim.Play("DoorClose");
            DoorOpen = false;
            StartCoroutine(camReturn());
        }

    }

    IEnumerator camReturn()
    {
        yield return new WaitForSeconds(2);
        cutsceneCAM.SetActive(false);
        playerCAM.SetActive(true);
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
