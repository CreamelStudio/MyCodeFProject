using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public GameObject[] pattern;

    private void Start()
    {
        StartCoroutine(bossPatternStart());
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
        yield return new WaitForSeconds(12);
        StartCoroutine(bossPatternLoot());
    }
}
