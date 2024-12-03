using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossDamageManager : MonoBehaviour
{
    public float bossMaxHP;
    public float bossHP;
    public Slider bossHPBar;

    [Header("보스스킬맞음!!")]
    public float bossHandDamage;

    public RawImage FadeIn;

    public AudioSource audioSource;

    private void Start()
    {
        bossHP = bossMaxHP;
        bossHPBar.maxValue = bossMaxHP;
        bossHPBar.value = bossHP;
    }

    private void Update()
    {
        if(bossHP <= 0)
        {
            FadeIn.DOFade(1, 2f);
            audioSource.DOFade(0, 0.5f);
            Invoke("ToCredit", 3f);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            bossHP -= 50;
            DOTween.To(() => bossHPBar.value, x => bossHPBar.value = x, bossHP, 0.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            bossHP -= other.GetComponent<BladeManager>().ReturnDamage();
        }
        else if (other.gameObject.CompareTag("Hand"))
        {
            bossHP -= bossHandDamage;
            Destroy(other.gameObject);
        }
        DOTween.To(() => bossHPBar.value, x => bossHPBar.value = x, bossHP, 0.3f);
    }

    private void ToCredit()
    {
        SceneManager.LoadScene("Credit");
    }
}
