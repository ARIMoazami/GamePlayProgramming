using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupText : MonoBehaviour
{

    public GameObject PopUpTxt;
    public bool textEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        PopUpTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(textEnabled)
        {
            PopUpTxt.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        textEnabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        textEnabled = true;
    }

}
