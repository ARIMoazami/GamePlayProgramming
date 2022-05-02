using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidChamber : MonoBehaviour
{
    public GameObject InteractText;
    public GameObject PortalGate;
    public GameObject MainChamber;
    public GameObject Player;

    public Animator ChamberAnim;
    public Animator gateAnim;

    public GameObject playercam;
    public GameObject cutscenecam;

    public bool hasLiquid = false;
    public int liquidLevel = 0;

    private bool inTrigger = false;

    public GameObject plant1;
    public GameObject plant2;
    public GameObject plant3;
    public GameObject plant4;


    // Start is called before the first frame update
    void Start()
    {
        InteractText.SetActive(false);

        cutscenecam.SetActive(false);

        PortalGate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasLiquid && inTrigger && Input.GetButtonDown("Interact"))
        {
            liquidLevel += 1;
            hasLiquid = false;
            plant1.GetComponent<InteractPlant>().enabled = true;
            plant2.GetComponent<InteractPlant>().enabled = true;
            plant3.GetComponent<InteractPlant>().enabled = true;
            plant4.GetComponent<InteractPlant>().enabled = true;
        }

        if (liquidLevel == 1)
        {
            ChamberAnim.Play("LiquidLvl1");
        }

        if (liquidLevel == 2)
        {
            ChamberAnim.Play("LiquidLvl2");
        }

        if (liquidLevel == 3)
        {
            ChamberAnim.Play("LiquidLvl3");
        }

        if (liquidLevel == 4)
        {
            ChamberAnim.Play("LiquidFinalLvl");
            StartCoroutine(gateReveal());
        }

    }

    IEnumerator gateReveal()
    {
        yield return new WaitForSeconds(1.5f);
        cutscenecam.SetActive(true);
        playercam.SetActive(false);
        PortalGate.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;
        gateAnim.Play("GateOpen");
        MainChamber.transform.position = new Vector3(0,-11, 0);
        liquidLevel = 0;
        StartCoroutine(returnCam());
    }

    IEnumerator returnCam()
    {
        yield return new WaitForSeconds(2f);
        playercam.SetActive(true);
        cutscenecam.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        InteractText.SetActive(true);
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        InteractText.SetActive(false);
        inTrigger = false;
    }
}
