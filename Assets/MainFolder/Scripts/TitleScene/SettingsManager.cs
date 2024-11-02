using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public RenderPipelineAsset[] renderer;

    void Start()
    {
        if(PlayerPrefs.GetInt("FirstBoot") != 1)
        {
            PlayerPrefs.SetFloat("MasterVol", 1);
            PlayerPrefs.SetFloat("MusicVol", 1);
            PlayerPrefs.SetFloat("SFXVol", 1);

            PlayerPrefs.SetFloat("MasterVol", 1);
            PlayerPrefs.SetFloat("MusicVol", 1);
            PlayerPrefs.SetFloat("SFXVol", 1);
        }
    }

    public void SetPipe(int value)
    {
        Debug.Log("Graphic Quality" + value);
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = renderer[value];
    }

    public void SetFPS(int value)
    {
        switch (value)
        {
            case 0:Application.targetFrameRate = 100000;break;
            case 1: Application.targetFrameRate = 240; break;
            case 2: Application.targetFrameRate = 144; break;
            case 3: Application.targetFrameRate = 120; break;
            case 4: Application.targetFrameRate = 75; break;
            case 5: Application.targetFrameRate = 60; break;
            case 6: Application.targetFrameRate = 30; break;
        }
    }
}
