using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveUI : MonoBehaviour
{

    public GameObject UIElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        UIElement.SetActive(false);
    }

    void OnTriggerExit(Collider other)
    {
        UIElement.SetActive(false);
    }
}
