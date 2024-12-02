using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class HandMagic : MonoBehaviour
{
    public GameObject magicCircle;
    public GameObject handOne;
    public GameObject[] handGroup;

    public float turnSpeed;

    private void Start()
    {
        transform.position = new Vector3(GameManager.Instance.player.transform.position.x, -0.32f, GameManager.Instance.player.transform.position.z);
        StartCoroutine(Co_HandToOut());
    }

    private void Update()
    {
        magicCircle.transform.Rotate(new Vector3(0, Time.deltaTime * turnSpeed, 0));
    }

    IEnumerator Co_HandToOut()
    {
        yield return new WaitForSeconds(1f);
        DOTween.To(() => turnSpeed, x => turnSpeed = x, 0, 0.5f);
        handOne.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        for (int i = 0; i < handGroup.Length; i++)
        {
            handGroup[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3);
        DOTween.To(() => turnSpeed, x => turnSpeed = x, 60, 1f);
    }
}
