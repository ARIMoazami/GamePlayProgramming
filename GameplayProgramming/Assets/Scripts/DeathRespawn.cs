using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    public Transform teleportLocation;

    public GameObject player;

    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(dead)
        {
            player.SetActive(false);
            StartCoroutine(Respawn());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        dead = true;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        dead = false;
        player.transform.position = teleportLocation.transform.position;
        player.SetActive(true);
    }
}
