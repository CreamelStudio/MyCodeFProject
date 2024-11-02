using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject[] highlight;
    public GameObject[] setHighLight;

    public GameObject settings;

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

    public void SetClickButton(int ButtonNumber)
    {
        switch (ButtonNumber)
        {
            case 0: Debug.Log("Sounds"); break;
            case 1: Debug.Log("Graphics"); break;
            case 2: Debug.Log("Control"); break;
            case 3: Debug.Log("System"); break;
            case 4: Debug.Log("Data"); break;
            case 5: Debug.Log("Save&Exit"); settings.SetActive(false); break;
        }
    }
}
