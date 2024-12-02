using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHPManager : MonoBehaviour
{
    public Slider hpSlider;
    public float maxPlayerHp;
    public float playerHp;

    public float handDamage;
    public float magicHandDamage;

    public Animator isDead;
    public AudioSource bgm;
    public AudioClip dead;

    public CanvasGroup ui;

    public bool deadBool;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hpSlider.maxValue = maxPlayerHp;
        hpSlider.value = maxPlayerHp;
        playerHp = maxPlayerHp;
    }

    private void Update()
    {
        if(playerHp <= 0 && !deadBool)
        {
            ui.DOFade(0, 0.3f);
            bgm.DOFade(0, 0.5f);
            isDead.gameObject.SetActive(true);
            StartCoroutine(Co_IsDead());
            deadBool = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand")) playerHp -= handDamage;
        if (other.gameObject.CompareTag("MagicHand")) playerHp -= magicHandDamage;

        DOTween.To(() => hpSlider.value, x => hpSlider.value = x, playerHp, 0.3f);
    }

    public void Restart()
    {
        isDead.SetBool("Restart", true);
        StartCoroutine(Co_Restart());
    }

    IEnumerator Co_IsDead()
    {
        yield return new WaitForSeconds(0.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DOTween.KillAll();
        bgm.clip = dead;
        bgm.volume = 0.6f;
        bgm.Play();
    }

    IEnumerator Co_Restart()
    {
        
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
