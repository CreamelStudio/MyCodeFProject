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
    public Text chatText;

    public GameObject blickBlack;
    public int blinkCount;
    public float blinkCool;
    public float startCool;

    public AudioSource violin;

    public bool isStartCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CutScene" && !isStartCutScene)
        {
            isStartCutScene = true;
            chat.SetActive(true);
            chatText.DOText("What's wrong?", 1);
            fireMove.transform.DOMoveX(-60, 15f).SetEase(Ease.InQuart);
            StartCoroutine(Co_ToNextScene());
            violin.Play();
        }
    }

    IEnumerator Co_ToNextScene()
    {
        yield return new WaitForSeconds(startCool);
        yield return new WaitForSeconds(blinkCool);
        chatText.DOText("what the .......", 3);
        blickBlack.SetActive(true);
        for (int i = 0; i < blinkCount; i++)
        {
            yield return new WaitForSeconds(blinkCool);
            blickBlack.SetActive(false);
            yield return new WaitForSeconds(blinkCool);
            blickBlack.SetActive(true);
        }
        SceneManager.LoadScene("Act2");
    }
}
