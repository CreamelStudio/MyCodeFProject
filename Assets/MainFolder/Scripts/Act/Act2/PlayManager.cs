using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayManager : MonoBehaviour
{

    public bool isKey;
    public bool isProg;
    public bool endProg;

    public Image keyBg;

    public float amount;

    public Material fadeMat;

    public GameObject dessolveObj;
    public GameObject normalChip;

    public GameObject disableOut;
    public Text des;

    public Tweener progressTwen;

    private void Start()
    {
        fadeMat.color = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) isKey = true;
        if (Input.GetKeyUp(KeyCode.F)) isKey = false;

        if (isKey == true && isProg != true)
        {
            isProg = true;
            progressTwen = DOTween.To(() => amount, x => amount = x, 1, 5);
        }
        else if(isKey == false && isProg == true && endProg == false)
        {
            isProg = false;
            amount = 0; 
            DOTween.KillAll();
            progressTwen = null;
        }
        keyBg.fillAmount = amount;

        if(amount == 1 && endProg == false)
        {
            fadeMat.DOFade(0, 1f);
            dessolveObj.SetActive(true);
            Invoke("DisableChip", 1);
            endProg = true;
        }
    }

    public void DisableChip()
    {
        normalChip.SetActive(false);
        Invoke("nextScene", 2f);
    }
    public void nextScene()
    {
        disableOut.SetActive(false);
        des.text = "";
        des.DOText("hahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahahaha", 5f);
        Invoke("ToCredit", 4);
    }

    public void ToCredit()
    {
        SceneManager.LoadScene("Credit");
    }
}
