using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartCycleManager : MonoBehaviour
{
    public GameObject heart;

    public GameObject heartDetect;

    public Animator anim;

    public float positionXMin;
    public float positionZMin;

    public float positionXMax;
    public float positionZMax;

    void Start()
    {
        anim = heart.GetComponent<Animator>();
        StartCoroutine(Co_SpDeControl());
    }
    IEnumerator Co_SpDeControl()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(0.5f);
        heart.SetActive(false);
        Vector3 initPosition = new Vector3(Random.RandomRange(positionXMin, positionXMax), 0.4459801f, Random.RandomRange(positionZMin, positionZMax));
        yield return new WaitForSeconds(1);
        heartDetect.transform.position = initPosition;
        heartDetect.SetActive(true);
        yield return new WaitForSeconds(4);
        heartDetect.SetActive(false);
        heart.transform.position = initPosition;
        heart.SetActive(true);
        yield return new WaitForSeconds(8);
        StartCoroutine(Co_SpDeControl());
    }
}
