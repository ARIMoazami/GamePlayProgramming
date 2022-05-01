using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Collectable_
{

    Powerup_StrongAttack powerup_strong_attack_script;

    

    private void Start()
    {
        Debug.Log("Powerup script");
        powerup_strong_attack_script = gameObject.AddComponent<Powerup_StrongAttack>();
        powerup_strong_attack_script.enabled = true;
    }

    public void callPowerup(string powerup_type)
    {

        switch (powerup_type)
        {
            case "STRONGATTACK":
                Debug.Log("Calling powerup: " + powerup_type);
                StartCoroutine(powerup_strong_attack_script.StrongAttack());
                break;

            default:

                break;
        }
    }

    public virtual void enablePowerup()
    {
        
    }

    public virtual void disablePowerup()
    {

    }
}
