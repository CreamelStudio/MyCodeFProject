using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeInOut : MonoBehaviour
{
    public float fadeOut;
    public float fadeIn;

    public RawImage fade;

    void Start()
    {
        if(fadeOut != 0)
        {
            fade.DOFade(0, fadeOut);
        }
        if (fadeIn != 0)
        {
            fade.DOFade(1, fadeIn);
        }
    }
}
