using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject UIText;
    public GameObject Door;

    private bool DoorOpen = false;
    private Animator buttonAnim;


    // Start is called before the first frame update
    void Start()
    {
        buttonAnim = GetComponent<Animator>();

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
            // open door
        }
        else if (InOverlap && DoorOpen && Input.GetButtonDown("Interact"))
        {
            buttonAnim.SetTrigger("Pressed");
            // close door
        }
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
