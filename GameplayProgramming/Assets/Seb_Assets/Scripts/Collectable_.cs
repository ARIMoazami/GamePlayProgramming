using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_ : MonoBehaviour
{
    
    public enum Type
    { 
        COIN,
        POWERUP
    };
    [Header("Type of collectable")]
    public Type type;

    
    public enum Powerup_Type
    {
        NONE,
        STRONGATTACK
    };
    [Header("If powerup:")]
    public Powerup_Type powerup_type;


    private GameObject player;
    private Powerup powerup_script;
    private Coin coin_script;

    
    private MeshRenderer mesh_renderer;
    private SphereCollider sphere_collider;

    
    private void Start()
    {
        if (type.ToString() == "COIN")
        {
            coin_script = gameObject.AddComponent<Coin>();
            coin_script.enabled = true;
        }
        else if (type.ToString() == "POWERUP")
        {
            powerup_script = gameObject.AddComponent<Powerup>();
            powerup_script.enabled = true;
        }
        
        player = GameObject.FindWithTag("Player");
        mesh_renderer = gameObject.GetComponent<MeshRenderer>();
        sphere_collider = gameObject.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (type.ToString() == "COIN")
            {
                coin_script.pickupCoin();
                Debug.Log("Player has collected a coin");
            }
            else if (type.ToString() == "POWERUP")
            {
                powerup_script.callPowerup(powerup_type.ToString());
                Debug.Log("Player has collected the " + powerup_type.ToString() + " powerup");
            }

            disableCollectable();
        }
    }

    private void disableCollectable()
    {
        mesh_renderer.enabled = false;
        sphere_collider.enabled = false;
    }


}
