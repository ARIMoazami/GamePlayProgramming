using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlant : MonoBehaviour
{
    public Material deadPlant;

    public GameObject Plant;
    public GameObject PlantTrigger;
    public GameObject Chamber;

    public GameObject plantText;

    private bool Overlap = false;

    public GameObject plant1;
    public GameObject plant2;
    public GameObject plant3;
    public GameObject plant4;


    // Start is called before the first frame update
    void Start()
    {
        plantText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Overlap && Input.GetButtonDown("Interact"))
        {
            Chamber.GetComponent<LiquidChamber>().hasLiquid = true;
            Plant.GetComponent<MeshRenderer>().material = deadPlant;
            PlantTrigger.GetComponent<BoxCollider>().isTrigger = false;
            plant1.GetComponent<InteractPlant>().enabled = false;
            plant2.GetComponent<InteractPlant>().enabled = false;
            plant3.GetComponent<InteractPlant>().enabled = false;
            plant4.GetComponent<InteractPlant>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        plantText.SetActive(true);

        Overlap = true;
    }

    void OnTriggerExit(Collider other)
    {
        plantText.SetActive(false);

        Overlap = false;
    }
}
