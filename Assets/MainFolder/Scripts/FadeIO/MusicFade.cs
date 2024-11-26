using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MusicFade : MonoBehaviour
{
    public float fadeOut;
    public float fadeIn;

    public AudioSource fade;

    void Start()
    {
        if (fadeOut != 0)
        {
            fade.DOFade(0, fadeOut);
        }
        if (fadeIn != 0)
        {
            fade.DOFade(1, fadeIn);
        }
    }
}
