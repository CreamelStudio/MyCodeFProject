using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Co_OffAnim());
    }

    IEnumerator Co_OffAnim()
    {
        yield return new WaitForSeconds(0.4f);
        GetComponent<Animator>().enabled = false;
    }
}
