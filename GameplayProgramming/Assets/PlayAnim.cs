using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{

    public Animator TrapAnim;


    // Start is called before the first frame update
    void Start()
    {
        TrapAnim.Play("SpearTrap");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
