using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidChamber : MonoBehaviour
{
    public GameObject InteractText;

    public Animator ChamberAnim;

    public bool hasLiquid = false;
    public int liquidLevel = 0;

    private bool inTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        InteractText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasLiquid && inTrigger && Input.GetButtonDown("Interact"))
        {
            liquidLevel += 1;
            hasLiquid = false;
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
        }
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
