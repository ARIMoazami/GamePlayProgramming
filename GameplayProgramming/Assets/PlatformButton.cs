using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformButton : MonoBehaviour
{
    public GameObject uiText;

    public Material Red;
    public Material Green;

    public bool On = true;

    private GameObject Button;
    


    // Start is called before the first frame update
    void Start()
    {


    }

    private bool InOverlap
    {
        get
        {
            return uiText.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InOverlap && On && Input.GetButtonDown("Interact"))
        {
            Button.GetComponent<MeshRenderer>().material = Red;

            On = false;

        }
        else if (InOverlap && !On && Input.GetButtonDown("Interact"))
        {
            Button.GetComponent<MeshRenderer>().material = Green;

            On = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        uiText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        uiText.SetActive(false);
    }
}
