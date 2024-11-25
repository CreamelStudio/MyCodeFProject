using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutSceneStart : MonoBehaviour
{
    public GameObject fireMove;
    public GameObject chat;

    public GameObject fadein;

    public Text chatText;

    public GameObject blickBlack;
    public int blinkCount;
    public float blinkCool;
    public float startCool;

    public GameObject cutSceneCamera;
    public GameObject mainCamera;

    public AudioSource mainAudio;
    public AudioClip fastBgm;

    public CanvasGroup cv;

    public bool isStartCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CutScene" && !isStartCutScene)
        {
            isStartCutScene = true;
            chat.SetActive(true);
            chatText.DOText("What's wrong?", 1);
            fireMove.transform.DOMoveX(-75, 16f).SetEase(Ease.InQuart);
            StartCoroutine(Co_ToNextScene());
            
        }
    }

    IEnumerator Co_ToNextScene()
    {
        mainAudio.DOFade(0, 1f);

        cutSceneCamera.SetActive(true);
        mainCamera.SetActive(false);
        
        yield return new WaitForSeconds(6.5f);
        cutSceneCamera.SetActive(false);
        mainCamera.SetActive(true);
        mainAudio.clip = fastBgm;
        mainAudio.Play();
        mainAudio.DOFade(1, 1f);
        yield return new WaitForSeconds(startCool - 2);
        
        yield return new WaitForSeconds(blinkCool);
        chatText.text = "";
        chatText.DOText("what the .......", 3);
        blickBlack.SetActive(true);
        fadein.GetComponent<RawImage>().DOFade(1, 3);
        cv.DOFade(0, 2);
        
        yield return new WaitForSeconds(3);
        mainAudio.DOFade(0, 1);
        for (int i = 0; i < blinkCount; i++)
        {
            yield return new WaitForSeconds(blinkCool - i * 1200);
            blickBlack.SetActive(false);
            yield return new WaitForSeconds(blinkCool - i * 1200);
            blickBlack.SetActive(true);
        }
        mainAudio.DOFade(0, 0.5f);
        SceneManager.LoadScene("Credit");
    }
}
