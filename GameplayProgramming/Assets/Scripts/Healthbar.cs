using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider healthSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BaseHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void Health(float health)
    {
        healthSlider.value = health;
    }
}
