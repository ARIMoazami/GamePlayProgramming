using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{

    public int Collectables;
    bool allCollected = false;
    Animator DoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        DoorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Collectables == 3)
        {
            allCollected = true;
        }


        if(allCollected)
        {
            DoorAnim.Play("SecretDoor");
        }
    }
}
