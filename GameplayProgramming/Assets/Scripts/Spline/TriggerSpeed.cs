using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpeed : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        this.transform.parent.GetComponent<Follow>().speed = 5;
        StartCoroutine(SpeedChange());
    }

    IEnumerator SpeedChange()
    {
        yield return new WaitForSeconds(4);
        this.transform.parent.GetComponent<Follow>().speed = 0;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
