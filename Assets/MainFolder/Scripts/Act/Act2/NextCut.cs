using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class NextCut : MonoBehaviour
{
    public GameObject fadeout;
    public AudioSource bgmAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CutScene"))
        {
            StartCoroutine(nextDelayScene());
        }
    }

    IEnumerator nextDelayScene()
    {
        bgmAudio.DOFade(0,0.7f);
        yield return new WaitForSeconds(0.5f);
        fadeout.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("Stage");
    }
}
