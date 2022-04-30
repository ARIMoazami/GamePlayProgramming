using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup_StrongAttack : Powerup
{

    public GameObject UI_image_go;
    [Range(5.0f, 15.0f)]
    public float duration = 10.0f;

    private Image UI_image;

    private void Start()
    {
        UI_image_go = GameObject.FindWithTag("StrongAttackImage");
        UI_image = UI_image_go.GetComponent<Image>();
        UI_image_go.SetActive(false);

        Debug.Log("Started powerup_strongAttack");
    }

    public IEnumerator StrongAttack()
    {
        enablePowerup();
        yield return new WaitForSeconds(duration);
        disablePowerup();
    }

    public override void enablePowerup()
    {
        UI_image_go.SetActive(true);
        UI_image.canvasRenderer.SetAlpha(1.0f);
        UI_image.CrossFadeAlpha(0.0f, duration, false);
    }

    public override void disablePowerup()
    {
        UI_image_go.SetActive(false);
    }
}
