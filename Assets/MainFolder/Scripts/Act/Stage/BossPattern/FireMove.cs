using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public GameObject firstFire;
    public GameObject secondFire;

    private void Start()
    {
        StartCoroutine(Co_FireLotStart());
    }

    IEnumerator Co_FireLotStart()
    {
        firstFire.SetActive(true);
        yield return new WaitForSeconds(4f);
        secondFire.SetActive(true);
        yield return new WaitForSeconds(4f);
        Destroy(firstFire,3);
        Destroy(secondFire,3);
    }
}
