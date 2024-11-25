using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public AudioSource audioS;

    private void Start()
    {
        audioS.DOFade(1, 3f);
    }
}
