using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject[] highlight;
    public GameObject[] setHighLight;

    public GameObject settings;

    public float deltatime;

    public Text fps;

    private void Start()
    {
        settings.SetActive(false);


    }


    public void HighLightB(int number)
    {
        for (int i = 0; i < highlight.Length; i++)
        {
            highlight[i].SetActive(false);
        }
        highlight[number].SetActive(true);
    }


    public void NoLight()
    {
        for (int i = 0; i < highlight.Length; i++)
        {
            highlight[i].SetActive(false);
        }
    }

    public void SettingHighLightB(int number)
    {
        for (int i = 0; i < setHighLight.Length; i++)
        {
            setHighLight[i].SetActive(false);
        }
        setHighLight[number].SetActive(true);
    }


    public void SettingNoLight()
    {
        for (int i = 0; i < setHighLight.Length; i++)
        {
            setHighLight[i].SetActive(false);
        }
    }

    public void TitleClickButton(int ButtonNumber)
    {
        switch (ButtonNumber)
        {
            case 0: Debug.Log("New Game"); break;
            case 1: Debug.Log("Continue"); break;
            case 2: Debug.Log("Setting"); settings.SetActive(true); break;
            case 3: Debug.Log("Gallery"); break;
            case 4: Debug.Log("Credit"); break;
            case 5: Debug.Log("Exit"); break;
        }
    }

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