using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveFire : MonoBehaviour
{
    public GameObject player;
    public float Distence;

    public GameObject moveTo;

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < Distence){

            transform.DOMove(moveTo.transform.position, 9f).SetEase(Ease.Linear);
        
        }
    }
}
