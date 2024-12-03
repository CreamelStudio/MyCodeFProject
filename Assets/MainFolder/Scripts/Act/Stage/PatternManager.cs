using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public GameObject[] pattern;

    private void Start()
    {
        StartCoroutine(bossPatternStart());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) Instantiate(pattern[0], transform);
        if (Input.GetKeyDown(KeyCode.Alpha1)) Instantiate(pattern[1], transform);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Instantiate(pattern[2], transform);

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopCoroutine(bossPatternStart());
            StopCoroutine(bossPatternLoot());
        }
    }

    IEnumerator bossPatternStart()
    {
        yield return new WaitForSeconds(18);
        StartCoroutine(bossPatternLoot());
    }
    IEnumerator bossPatternLoot()
    {
        int patternRandom = Random.Range(0, pattern.Length);
        Debug.Log($"Pattern Init {patternRandom}");
        Instantiate(pattern[patternRandom], transform);
        yield return new WaitForSeconds(Random.Range(8,11));
        StartCoroutine(bossPatternLoot());
    }
}
