using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFps : MonoBehaviour
{
    public int avgframe;
    public Text display_text;

    // Update is called once per frame
    void Update()
    {
        float current = 0;
        current = Time.frameCount / Time.deltaTime;
        avgframe = (int)current;
        display_text.text = "FPS: " + avgframe.ToString();
    }
}