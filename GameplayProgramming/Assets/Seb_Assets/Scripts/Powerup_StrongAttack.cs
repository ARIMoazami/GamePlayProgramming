using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup_StrongAttack : Powerup
{

    public GameObject UI_image_go;
    public float duration = 3.0f;

    private GameObject strength_text_go;
    private Text strength_text_txt;

    private GameObject player;
    private PlayerMovement player_script;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        player_script = player.GetComponent<PlayerMovement>();

        strength_text_go = GameObject.FindWithTag("StrengthText");
        strength_text_txt = strength_text_go.GetComponent<Text>();

        strength_text_go.SetActive(false);

    Debug.Log("Started powerup_strongAttack");
    }

    public void StrongAttack()
    {
        enablePowerup();
        
    }

    public override void enablePowerup()
    {
        player_script.setStrongAttack(true);
        strength_text_go.SetActive(true);
        strength_text_txt.canvasRenderer.SetAlpha(1.0f);
        strength_text_txt.CrossFadeAlpha(0.0f, duration, false);

    }

    public override void disablePowerup()
    {
        Debug.Log("Disabled Powerup");
        player_script.setStrongAttack(false);
    }
}
