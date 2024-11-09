using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPSView : MonoBehaviour
{
    public Text fps;
    public float deltatime;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) fps.gameObject.SetActive(!fps.gameObject.activeSelf);
        fps.text = "FPS\n" + OutputFPS().ToString();

    }

    float OutputFPS()
    {
        deltatime += (Time.deltaTime - deltatime) * 0.1f;
        float fps = 1.0f / deltatime;

        return fps;
    }
}
