using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkUI : MonoBehaviour
{
    public Player player;

    public GameObject blickBlack;
    public GameObject title;
    public AudioClip riser;
    public AudioClip bassClip;
    public AudioClip bgm;

    public float blinkCool;
    public float startOffset;
    public float bassOffset;
    public int blinkCount;

    public AudioSource audioSource;

    public 

    void Start()
    {
        StartCoroutine(blickStart());
       
    }

    IEnumerator blickStart()
    {
        yield return new WaitForSeconds(startOffset);
        
        yield return new WaitForSeconds(blinkCool);
        blickBlack.SetActive(true);
        player.SwitchCanMove();
        audioSource.clip = riser;
        audioSource.Play();
        for (int i=0;i< blinkCount; i++)
        {
            yield return new WaitForSeconds(blinkCool - i / 1000);
            blickBlack.SetActive(false);
            yield return new WaitForSeconds(blinkCool - i / 1000);
            blickBlack.SetActive(true);
        }

        audioSource.clip = bassClip;
        audioSource.Play();
        title.SetActive(true);
        yield return new WaitForSeconds(bassOffset);
        
        blickBlack.GetComponent<RawImage>().DOFade(0, 4);
        title.GetComponent<RawImage>().DOFade(0, 4);
        yield return new WaitForSeconds(bassOffset);
        player.SwitchCanMove();
        audioSource.volume = 0.12f;
        audioSource.loop = true;
        audioSource.clip = bgm;
        audioSource.Play();
    }
}
