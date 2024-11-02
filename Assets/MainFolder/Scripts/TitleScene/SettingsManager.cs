using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static UnityEngine.Rendering.DebugUI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private RenderPipelineAsset[] renderer;

    [SerializeField]
    private GameObject[] SetList;

    [SerializeField]
    private GameObject viewer;

    #region SetValue
    [Header("설정 Value")]
    [SerializeField]
    private Scrollbar masterVol;
    [SerializeField]
    private Scrollbar musicVol;
    [SerializeField]
    private Scrollbar sfxVol;
    [SerializeField]
    private Text interectionKeyText;
    [SerializeField]
    private Text InventoryKeyText;
    [SerializeField]
    private Dropdown quality;
    [SerializeField]
    private Dropdown fps;
    #endregion

    void Start()
    {
        if (PlayerPrefs.GetInt("FirstBoot") != 1)
        {
            PlayerPrefs.SetFloat("MasterVol", 1);
            PlayerPrefs.SetFloat("MusicVol", 1);
            PlayerPrefs.SetFloat("SFXVol", 1);

            PlayerPrefs.SetString("InterectionKey", "F");
            PlayerPrefs.SetString("InventoryKey", "E");

            PlayerPrefs.SetInt("Quality", 2);
            PlayerPrefs.SetInt("FPS", 0);

            SetFPS(0);
            SetPipe(2);
        }


    }

    public void SetKey(int value)
    {
        //0 -> Interection 1 -> InventoryKey

        if(value == 0)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) //KeyCode 의 Value중 kcode와 같은것을 검색
            {
                if (Input.GetKeyDown(kcode))
                {
                    PlayerPrefs.SetString("InterectionKey", kcode.ToString().ToUpper());
                    interectionKeyText.text = kcode.ToString().ToUpper();
                    KeyCode keyCode;
                    System.Enum.TryParse(PlayerPrefs.GetString("InterectionKey"), true, out keyCode);
                    Debug.Log(keyCode);
                }
            }
        }
        if(value == 1)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    PlayerPrefs.SetString("InventoryKey", kcode.ToString().ToUpper());
                    InventoryKeyText.text = kcode.ToString().ToUpper();
                    KeyCode keyCode;
                    System.Enum.TryParse(PlayerPrefs.GetString("InventoryKey"), true, out keyCode);
                    Debug.Log(keyCode);
                }
            }
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
            case 0:Application.targetFrameRate = -1;break;
            case 1: Application.targetFrameRate = 240; break;
            case 2: Application.targetFrameRate = 144; break;
            case 3: Application.targetFrameRate = 120; break;
            case 4: Application.targetFrameRate = 75; break;
            case 5: Application.targetFrameRate = 60; break;
            case 6: Application.targetFrameRate = 30; break;
        }
    }

    public void SetViewer(int value)
    {
        if (value == 5) SetLeaveData();
        else
        {
            foreach (GameObject view in SetList) view.SetActive(false);
            SetList[value].SetActive(true);
        }
    }

    public void SetLeaveData()
    {
        PlayerPrefs.SetFloat("MasterVol", masterVol.value);
        PlayerPrefs.SetFloat("MusicVol", musicVol.value);
        PlayerPrefs.SetFloat("SFXVol", sfxVol.value);

        PlayerPrefs.SetString("InterectionKey", interectionKeyText.text);
        PlayerPrefs.SetString("InventoryKey", InventoryKeyText.text);

        PlayerPrefs.SetInt("Quality", quality.value);
        PlayerPrefs.SetInt("FPS", fps.value);
        viewer.SetActive(false);
    }
}
