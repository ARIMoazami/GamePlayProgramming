using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{

    public int Collectables;

    public GameObject playercam;
    public GameObject doorcam;

    bool allCollected = false;
    Animator DoorAnim;

    public GameObject gemUI;

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
            doorcam.SetActive(true);
            playercam.SetActive(false);
            StartCoroutine(normCam());
        }

        if(Collectables == 4)
        {
            gemUI.GetComponent<PopupText>().textEnabled = false;
        }


        if(allCollected)
        {
            DoorAnim.Play("SecretDoor");
        }
    }

    IEnumerator normCam()
    {
        yield return new WaitForSeconds(1.5f);
        doorcam.SetActive(false);
        playercam.SetActive(true);
        Collectables = 4;
    }
}
