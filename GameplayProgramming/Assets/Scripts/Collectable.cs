using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public GameObject uiText;
    public GameObject SecretDoor;

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        uiText.SetActive(true);
        StartCoroutine(DisappearText());

        SecretDoor.GetComponent<OpenSecretDoor>().Collectables += 1;
    }

    IEnumerator DisappearText()
    {
        yield return new WaitForSeconds(1);
        uiText.SetActive(false);
        Destroy(gameObject);
    }
}
